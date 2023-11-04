using System;
using System.Collections.Generic;

namespace Clicker.Architecture {
    public class RepositoriesBase {

        private Dictionary<Type, Repository> repositoriesMap;
        private SceneConfig sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig) {
            this.sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories() {
            repositoriesMap = sceneConfig.CreateAllRepositories();
        }

        
        public void SendOnCreateToAllRepositories() {
            var allRepositories = repositoriesMap.Values;
            foreach (var repository in allRepositories) {
                repository.OnCreate();
            }
        }
        
        public void InitializeAllRepositories() {
            var allRepositories = repositoriesMap.Values;
            foreach (var repository in allRepositories) {
                repository.Initialize();
            }
        }
        
        public void SendOnStartAllRepositories() {
            var allRepositories = repositoriesMap.Values;
            foreach (var repository in allRepositories) {
                repository.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository {
            var type = typeof(T);
            return (T) repositoriesMap[type];
        }
    }
}
