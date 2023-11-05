namespace Clicker.Architecture {
    public class LevelInteractor : Interactor {
        
        private float maxExpInLevel = 10000f;

        public int level => repository.level;
        public float experience => repository.expirience;

        private LevelRepository repository;

        public override void OnCreate() {
            base.OnCreate();
            repository = Game.GetRepository<LevelRepository>();
        }

        public override void Initialize() {
            Level.Initialize(this);
        }
        
        public void AddExperience(object sender, float value) {
            if (value + GetExperienceCurrentLevel() < maxExpInLevel) {
                repository.expirience += value;
                repository.Save();
            }
            else {
                repository.expirience += value;
                repository.level++;
                repository.Save();
            }
        }

        public void Reset(object sender) {
            repository.level = 1;
            repository.expirience = 10000f;
            repository.Save();
        }

        private float GetExperienceCurrentLevel() {
            float exp = experience - (level * maxExpInLevel); 
            return exp;
        }
    }
}


