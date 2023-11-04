using UnityEngine;

namespace Clicker.Architecture {
    public class HeroRepository : Repository{
        
        private const string KEY = "HERO_";
        
        public int id { get; set; }
        public string name { get; set; }
        public float attack { get; set; }
        public int rank { get; set; }
        
        public override void Initialize() {
            name = PlayerPrefs.GetString(KEY+"NAME", "DefaultHero");
            id = PlayerPrefs.GetInt(KEY+"ID", 0);
            attack = PlayerPrefs.GetFloat(KEY+"ATTACK", 1);
            rank = PlayerPrefs.GetInt(KEY+"RANK", 0);
        }

        public override void Save() {
            PlayerPrefs.SetString(KEY+"NAME", name);
            PlayerPrefs.SetInt(KEY+"ID", id);
            PlayerPrefs.SetFloat(KEY+"ATTACK", attack);
            PlayerPrefs.SetInt(KEY+"RANK", rank);
        }
    }
}