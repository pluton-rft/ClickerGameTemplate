using UnityEngine;

namespace Clicker.Architecture {
    public class LevelRepository : Repository {

        private const string KEY = "LEVEL_";
        
        public int level { get; set; }
        public float expirience { get; set; }

        public override void Initialize() {
            level = PlayerPrefs.GetInt(KEY, 1);
            expirience = PlayerPrefs.GetFloat(KEY + "exp", 100000f);
        }

        public override void Save() {
            PlayerPrefs.SetInt(KEY, level);
            PlayerPrefs.SetFloat(KEY + "exp", expirience);
        }
    }
}
