using Clicker.Architecture;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelector : MonoBehaviour {
    
    [SerializeField] private HeroInfo heroInfo;
    [SerializeField] private bool _isActive;

    private void Awake() {
        Game.OnGameInitializeEvent += Initialize;
    }

    private void Initialize() {
        Bank.OnBankChangeBalanceEvent += UpdateActivateButton;
        Hero.DeactivateAllHeroes += DeactivateButton;
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
        SetHeroImage();
        UpdateActivateButton();
        Game.OnGameInitializeEvent -= Initialize;
    }

    private void OnDisable() {
        Hero.DeactivateAllHeroes -= DeactivateButton;
        Bank.OnBankChangeBalanceEvent -= UpdateActivateButton;
        GetComponent<Button>().onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick() {
        SetThisHeroActive();
    }

    public void SetThisHeroActive() {
        Hero.SetNewStats(this, heroInfo);
        _isActive = true;
    }

    private void SetHeroImage() {
        GetComponent<Image>().sprite = heroInfo.image;
    }
    
    public void UpdateActivateButton() {
        GetComponent<Button>().interactable = _isActive;
        if (Bank.coins >= heroInfo.price && Level.level >= heroInfo.levelAccess) {
            GetComponent<Button>().interactable = true;
        }
    }

    public void DeactivateButton() {
        if (_isActive) {
            GetComponent<Button>().interactable = false;
            _isActive = false;
        }
    }
}

