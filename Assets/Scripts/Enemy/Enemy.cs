using System;
using UnityEngine;

namespace Clicker.Architecture {
    public class Enemy {

        public static event Action OnEnemyInitializedEvent;
        public static event Action EnemyHealthChanged;
        public static event Action EnemyNameChanged;

        public static float maxHealth {
            get {
                CheckClass();
                return enemyInteractor.maxHealth;
            }
        }
        
        public static float currentHealth {
            get {
                CheckClass();
                return enemyInteractor.currentHealth;
            }
        }
        
        public static string name {
            get {
                CheckClass();
                return enemyInteractor.name;
            }
        }
        
        public static Sprite skin {
            get {
                CheckClass();
                return enemyInteractor.skin;
            }
        }
        
        public static bool isInitialized { get; private set; }

        private static EnemyInteractor enemyInteractor;

        public static void Initialize(EnemyInteractor interactor) {
            enemyInteractor = interactor;
            isInitialized = true;
            OnEnemyInitializedEvent?.Invoke();
        }

        public static void ApplyDamage(object sender, float value) {
            CheckClass();
            enemyInteractor.ApplyDamage(sender, value);
            EnemyHealthChanged?.Invoke();
        }

        public static void SetTemplate(object sender, EnemyTemplate template) {
            CheckClass();
            enemyInteractor.SetTemplate(sender, template);
        }

        public static void SpawnDefaultEnemy(object sender) {
            CheckClass();
            enemyInteractor.SpawnDefaultEnemy(sender);
            EnemyHealthChanged?.Invoke();
        }

        private static void CheckClass() {
            if (!isInitialized)
                throw new Exception("Enemy is not initialize yet");
        }
    }
}