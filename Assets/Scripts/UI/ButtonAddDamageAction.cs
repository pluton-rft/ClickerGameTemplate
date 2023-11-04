using Clicker.Architecture;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAddDamageAction : MonoBehaviour {

    [SerializeField] private Button button;

    private void Start() {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable() {
        button.onClick.RemoveListener(OnButtonClick);
    }

    public void OnButtonClick() {
        Enemy.ApplyDamage(this, Hero.attack);
    }
}
