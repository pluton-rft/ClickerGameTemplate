using UnityEngine;

namespace Clicker.Architecture {
    public class Clicker : MonoBehaviour {
        
        private void Start() {
            Game.Run();
        }
        
        private void Update() {
            if (!Bank.isInitialized)
                return;
            
            
            if (Input.GetKeyDown(KeyCode.A)) {
                Bank.AddCoins(this, 5000);
                Level.AddExperience(this, 10000f);
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                Bank.Spend(this, 10000);
            }
            
            if (Input.GetKeyDown(KeyCode.R)) {
                Bank.Reset(this); 
                Level.Reset(this); 
                Enemy.SpawnDefaultEnemy(this);
                Hero.ResetHeroes(this);
            } 
        }
    }
}