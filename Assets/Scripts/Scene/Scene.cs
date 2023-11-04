using System.Collections;
using UnityEngine;

namespace Clicker.Architecture {
    public class Scene {

        private InteractorsBase interactorsBase;
        private RepositoriesBase repositoriesBase;
        private SceneConfig sceneConfig;

        public Scene(SceneConfig config) {
            sceneConfig = config;
            interactorsBase = new InteractorsBase(config);
            repositoriesBase = new RepositoriesBase(config);

        }

        public Coroutine InitializeAsync() {
            return Coroutines.StartRoutine(InitializeRoutine());
        }

        private IEnumerator InitializeRoutine() {
            interactorsBase.CreateAllInteractors();
            repositoriesBase.CreateAllRepositories();
            yield return null;
            
            interactorsBase.SendOnCreateToAllInteractors();
            repositoriesBase.SendOnCreateToAllRepositories();
            yield return null;
            
            interactorsBase.InitializeAllInteractors();
            repositoriesBase.InitializeAllRepositories();
            yield return null;
            
            interactorsBase.SendOnStartAllInteractors();
            repositoriesBase.SendOnStartAllRepositories();
        }

        public T GetRepository<T>() where T : Repository {
            return repositoriesBase.GetRepository<T>();
        }
        
        public T GetInteractor<T>() where T : Interactor {
            return interactorsBase.GetInteractor<T>();
        }

    }
}