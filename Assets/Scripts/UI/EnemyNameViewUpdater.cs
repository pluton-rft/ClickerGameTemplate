using Clicker.Architecture;
using TMPro;
using UnityEngine;

public class EnemyNameViewUpdater : MonoBehaviour {
    private void Awake() {
        EnemyInteractor.EnemyTemplateUpdated += TextUpdate;
    }

    private void OnDisable() {
        EnemyInteractor.EnemyTemplateUpdated -= TextUpdate;
    }

    private void TextUpdate() {
        GetComponent<TMP_Text>().text = Enemy.name;
    }
}
