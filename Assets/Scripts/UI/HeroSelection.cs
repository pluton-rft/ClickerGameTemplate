using Clicker.Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelector : MonoBehaviour {
    
    [SerializeField] private HeroInfo _heroInfo;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _nameText;
    private int _isActive = 0;
    private int _isPurchased = 0;
    private const string KEY = "HERO_";

    private void Awake() {
        Game.OnGameInitializeEvent += Initialize;
    }

    private void Initialize() {
        Bank.OnBankChangeBalanceEvent += UpdateActivateButton;
        Hero.DeactivateAllHeroes += OnDeactivateAllHeroes;
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
        Load();
        SetHeroImage();
        UpdateActivateButton();
        UpdateButtonInfo();
        Game.OnGameInitializeEvent -= Initialize;
    }

    private void OnDisable() {
        Hero.DeactivateAllHeroes -= OnDeactivateAllHeroes;
        Bank.OnBankChangeBalanceEvent -= UpdateActivateButton;
        GetComponent<Button>().onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick() {
        SetThisHeroActive();
        if (_isPurchased == 0) Purchase();
        Save();
    }

    private void OnDeactivateAllHeroes() {
        _isActive = 0;
        _isPurchased = 0;
        Save();
        UpdateActivateButton();
    }

    private void SetThisHeroActive() {
        Hero.SetNewStats(this, _heroInfo);
        _isActive = 1;
    }

    private void SetHeroImage() {
        GetComponent<Image>().sprite = _heroInfo.image;
    }

    private void Purchase() {
        Bank.Spend(this,_heroInfo.price);
        _isPurchased = 1;
        Bank.OnBankChangeBalanceEvent -= UpdateActivateButton;
    }

    private void UpdateActivateButton() {
        GetComponent<Button>().interactable = _isActive == 1;
        if (_isActive == 0) {
            if (Bank.coins >= _heroInfo.price && Level.level >= _heroInfo.levelAccess) {
                GetComponent<Button>().interactable = true;
            }
        }
    }

    private void UpdateButtonInfo() {
        UpdateTextHeroCost();
        UpdateTextHeroName();
        UpdateTextHeroLevel();
    }

    private void UpdateTextHeroName() {
        _nameText.text = _heroInfo.name;
    }

    private void UpdateTextHeroLevel() {
        _levelText.text = _heroInfo.levelAccess.ToString();
    }

    private void UpdateTextHeroCost() {
        _priceText.text = _heroInfo.price.ToString();
    }

    private void Save() {
        PlayerPrefs.SetInt(KEY+_heroInfo.name+"_isActive", _isActive);
        PlayerPrefs.SetInt(KEY+_heroInfo.name+"_isPurchased", _isPurchased);
    }

    private void Load() {
        _isActive = PlayerPrefs.GetInt(KEY+_heroInfo.name+"_isActive", 0);
        _isPurchased = PlayerPrefs.GetInt(KEY+_heroInfo.name+"_isPurchased", 0);
    }
}

