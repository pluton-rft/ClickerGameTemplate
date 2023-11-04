using UnityEngine;

namespace Clicker.Architecture {
    public class EnemyRepository : Repository {
        
        private const string KEY = "ENEMY_";
        public string name { get; set; }
        public int id { get; set; }
        public float experienceReward { get; set; }
        public float moneyReward { get; set; }
        public float currentHealth { get; set; }
        public float maxHealth { get; set; }
        public Sprite image { get; set; }

        public float baseExperienceReward = 7770.0f;
        public float baseMoneyReward = 10000.0f;
        public float baseHealth = 200.0f;

        public override void Initialize() {
            experienceReward = PlayerPrefs.GetFloat(KEY+"EXP", baseExperienceReward);
            moneyReward = PlayerPrefs.GetFloat(KEY+"REWARD", baseMoneyReward);
            currentHealth = PlayerPrefs.GetFloat(KEY+"HEALTH", baseHealth);
            maxHealth = PlayerPrefs.GetFloat(KEY+"HEALTH", baseHealth);
        }

        public override void Save() {
            PlayerPrefs.SetFloat(KEY+"EXP", experienceReward);
            PlayerPrefs.SetFloat(KEY+"REWARD", moneyReward);
            PlayerPrefs.SetFloat(KEY+"HEALTH", maxHealth);
        }

        public void Reset() {
            PlayerPrefs.DeleteKey(KEY+"EXP");
            PlayerPrefs.DeleteKey(KEY+"REWARD");
            PlayerPrefs.DeleteKey(KEY+"HEALTH");
            Initialize();
            Save();
        }
    }
}
