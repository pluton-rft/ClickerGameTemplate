using System;

namespace Clicker.Architecture {
    public class Level {

        public static event Action OnLevelInitializedEvent;
        public static event Action OnLevelChangeLevelEvent;

        public static int level {
            get {
                CheckClass();
                return levelInteractor.level;
            }
        }

        public static float experience {
            get {
                CheckClass();
                return levelInteractor.experience;
            }
        }
        
        public static bool isInitialized { get; private set; }

        private static LevelInteractor levelInteractor;
        private static int _currentLevel;

        public static void Initialize(LevelInteractor interactor) {
            levelInteractor = interactor;
            isInitialized = true;
            OnLevelInitializedEvent?.Invoke();
        }
        
        public static void AddExperience(object sender, float value) {
            CheckClass();
            levelInteractor.AddExperience(sender, value);
            OnLevelChangeLevelEvent?.Invoke();
        }
        
        public static void Reset(object sender) {
            CheckClass();
            levelInteractor.Reset(sender);
            OnLevelChangeLevelEvent?.Invoke();
        }
        
        private static void CheckClass() {
            if (!isInitialized)
                throw new Exception("Level is not initialize yet");
        }
    }
}