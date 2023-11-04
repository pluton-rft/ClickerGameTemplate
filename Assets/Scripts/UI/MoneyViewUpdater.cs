using Clicker.Architecture;
using TMPro;
using UnityEngine;

public class MoneyViewUpdater : MonoBehaviour
{
    void Start() {
        Game.OnGameInitializeEvent += TextUpdate;
        Bank.OnBankChangeBalanceEvent += TextUpdate;
    }

    private void OnDisable() {
        Bank.OnBankChangeBalanceEvent -= TextUpdate;
    }

    void TextUpdate() {
        gameObject.GetComponentInParent<TMP_Text>().text = $"${Bank.coins.ToString()}";
        Game.OnGameInitializeEvent -= TextUpdate;
    }
}
