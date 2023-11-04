using Clicker.Architecture;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private void Awake() {
        Game.OnGameInitializeEvent += ChangeFillHealthBar;
        Enemy.EnemyHealthChanged += ChangeFillHealthBar;
    }

    private void OnDisable() {
        Enemy.EnemyHealthChanged -= ChangeFillHealthBar;
    }

    private void ChangeFillHealthBar() {
        GetComponent<Image>().fillAmount = Enemy.currentHealth / Enemy.maxHealth;
        Game.OnGameInitializeEvent -= ChangeFillHealthBar;
    }
}
