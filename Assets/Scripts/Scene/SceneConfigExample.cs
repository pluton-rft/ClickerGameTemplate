using System;
using System.Collections.Generic;

namespace Clicker.Architecture {
    public class SceneConfigExample : SceneConfig {

        public const string SCENE_NAME = "SampleScene";

        public override string sceneName => SCENE_NAME;
        public override Dictionary<Type, Repository> CreateAllRepositories() {
            var repositoriesMap = new Dictionary<Type, Repository>();

            CreateRepository<BankRepository>(repositoriesMap);
            CreateRepository<EnemyRepository>(repositoriesMap);
            CreateRepository<HeroRepository>(repositoriesMap);
            CreateRepository<LevelRepository>(repositoriesMap);

            return repositoriesMap;
        }

        public override Dictionary<Type, Interactor> CreateAllInteractors() {
            var interactorsMap = new Dictionary<Type, Interactor>();

            CreateInteractor<BankInteractor>(interactorsMap);
            CreateInteractor<EnemyInteractor>(interactorsMap);
            CreateInteractor<HeroInteractor>(interactorsMap);
            CreateInteractor<LevelInteractor>(interactorsMap);
            
            return interactorsMap;
        }
    }
}