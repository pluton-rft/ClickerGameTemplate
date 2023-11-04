using Clicker.Architecture;
using TMPro;
using UnityEngine;

public class LevelViewUpdater : MonoBehaviour
{
    void Start() {
        Game.OnGameInitializeEvent += TextUpdate;
        Level.OnLevelChangeLevelEvent += TextUpdate;
    }

    private void OnDisable() {
        Level.OnLevelChangeLevelEvent -= TextUpdate;
    }

    void TextUpdate() {
        gameObject.GetComponentInParent<TMP_Text>().text = Level.level.ToString();
        Game.OnGameInitializeEvent -= TextUpdate;
    }
}
