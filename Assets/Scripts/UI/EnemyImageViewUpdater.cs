using Clicker.Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class EnemyImageViewUpdater : MonoBehaviour{
        private void Awake() {
            EnemyInteractor.EnemyTemplateUpdated += UpdateImage;
        }

        private void OnDisable() {
            EnemyInteractor.EnemyTemplateUpdated -= UpdateImage;
        }

        private void UpdateImage() {
            this.GetComponent<Image>().sprite = Enemy.skin;
        }
    }
}