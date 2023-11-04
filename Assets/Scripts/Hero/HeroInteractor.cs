namespace Clicker.Architecture {
    public class HeroInteractor : Interactor {
        public float attack => repository.attack;

        private HeroRepository repository;

        public override void OnCreate() {
            base.OnCreate();
            repository = Game.GetRepository<HeroRepository>();
        }

        public override void Initialize() {
            Hero.Initialize(this);
        }

        public void SetStats(object sender, HeroInfo info) {
            repository.name = info.name;
            repository.attack = info.attack;
            repository.id = info.id;
            repository.rank = info.rank;
        }
    }
}