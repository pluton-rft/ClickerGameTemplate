using System;
using UnityEngine;

namespace Clicker.Architecture {
    public class EnemyInteractor : Interactor {

        public static event Action EnemyKilled;
        public static event Action EnemyTemplateUpdated; 
        
        public float currentHealth => repository.currentHealth;
        public float maxHealth => repository.maxHealth;
        public float moneyReward => repository.moneyReward;
        public float experienceReward => repository.experienceReward;
        public string name => repository.name;
        public Sprite skin => repository.image;

        private EnemyRepository repository;
        private float _experienceMultiply = 1.04f;
        private float _rewardMultiply = 1.1f;
        private float _healthMultiply = 1.08f;

        public override void OnCreate() {
            base.OnCreate();
            repository = Game.GetRepository<EnemyRepository>();
        }

        public override void Initialize() {
            Enemy.Initialize(this);
        }
        
        public void SetTemplate(object sender, EnemyTemplate template) {
            repository.name = template.name;
            repository.image = template.image;
            repository.Save();
            EnemyTemplateUpdated?.Invoke();
        }

        public void VictoryOverEnemy(object sender) {
            Bank.AddCoins(this, (int)moneyReward);
            Level.AddExperience(this, experienceReward);
        }

        public void Death(object sender) {
            EnemyKilled?.Invoke();
        }

        public void SetNewSpecsDependingLevel(object sender, float multiply = 1.0f ) {
            repository.maxHealth = multiply * (repository.baseHealth * (float)Math.Pow(_healthMultiply,(float)Level.level));
            repository.currentHealth = repository.maxHealth;
            repository.moneyReward = multiply * (repository.baseMoneyReward *(float)Math.Pow(_rewardMultiply,(float)Level.level));
            repository.experienceReward = repository.baseExperienceReward * (float)Math.Pow(_experienceMultiply,(float)Level.level);
            repository.Save();
        }
        
        public void ApplyDamage(object sender, float damage) {
            repository.currentHealth -= damage;
            if (repository.currentHealth < 0) {
                VictoryOverEnemy(this);
                SetNewSpecsDependingLevel(this);
                Death(this);
            }
        }
        
        public void SpawnDefaultEnemy(object sender) {
            repository.Reset();
        }
    }
}


