namespace Clicker.Architecture {
    public class BankInteractor : Interactor {
        public int coins => repository.coins;

        private BankRepository repository;

        public override void OnCreate() {
            base.OnCreate();
            repository = Game.GetRepository<BankRepository>();
        }

        public override void Initialize() {
            Bank.Initialize(this);
        }

        public bool IsEnoughCoins(int value) {
            return coins >= value;
        }

        public void AddCoins(object sender, int value) {
            if (value >= 0) {
                repository.coins += value;
                repository.Save();
            }
        }

        public void Spend(object sender, int value) {
            if (IsEnoughCoins(value) && value <= 0) {
                repository.coins -= value;
                repository.Save();
            }
        }
        
        public void Reset(object sender) {
            repository.coins = 0;
            repository.Save();
        }

    }
}


