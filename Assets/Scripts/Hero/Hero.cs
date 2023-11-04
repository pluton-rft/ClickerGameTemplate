using System;

namespace Clicker.Architecture {
    public class Hero {
        public static event Action OnHeroInitializedEvent;
        public static event Action DeactivateAllHeroes;

        public static float attack {
            get {
                CheckClass();
                return heroInteractor.attack;
            }
        }
        
        public static bool isInitialized { get; private set; }

        private static HeroInteractor heroInteractor;
        
        public static void Initialize(HeroInteractor interactor) {
            heroInteractor = interactor;
            isInitialized = true;
            OnHeroInitializedEvent?.Invoke();
        }

        public static void SetNewStats(object sender, HeroInfo info) {
            CheckClass();
            heroInteractor.SetStats(sender, info);
        }

        public static void ResetActiveHeroes(object sender) {
            CheckClass();
            DeactivateAllHeroes?.Invoke();
        }

        private static void CheckClass() {
            if (!isInitialized)
                throw new Exception("Hero is not initialize yet");
        }
    }
}