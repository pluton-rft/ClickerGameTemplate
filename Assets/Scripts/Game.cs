using System;
using System.Collections;

namespace Clicker.Architecture {
    public static class Game {

        public static event Action OnGameInitializeEvent;

        public static SceneManagerBase sceneManager { get; private set; }

        public static void Run() {
            sceneManager = new SceneManagerExample();
            Coroutines.StartRoutine(InitializeGameRoutine());
        }

        private static IEnumerator InitializeGameRoutine() {
            sceneManager.InitSceneMap();
            yield return sceneManager.LoadCurrentSceneAsync();
            OnGameInitializeEvent?.Invoke();
        }
        
        public static T GetInteractor<T>() where T : Interactor {
            return sceneManager.GetInteractor<T>();
        }
        
        public static T GetRepository<T>() where T : Repository {
            return sceneManager.GetRepository<T>();
        }

    }
}