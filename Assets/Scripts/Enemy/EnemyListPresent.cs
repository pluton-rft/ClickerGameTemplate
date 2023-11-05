using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Architecture {
    public class EnemyListPresent : MonoBehaviour {

        public static EnemyListPresent instance { get; private set; }
        public List<EnemyTemplate> enemyTemplatesList;
        
        private void Awake() {
            if (instance == null) {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
                return;
            }
            Destroy(this.gameObject);
        }

        public List<EnemyTemplate> GetTemplates() {
            return enemyTemplatesList;
        }
    }
}