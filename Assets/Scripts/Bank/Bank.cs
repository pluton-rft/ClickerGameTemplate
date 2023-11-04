using System;

namespace Clicker.Architecture {
    public class Bank {

        public static event Action OnBankInitializedEvent;
        public static event Action OnBankChangeBalanceEvent;

        public static int coins {
            get {
                CheckClass();
                return bankInteractor.coins;
            }
        }
        public static bool isInitialized { get; private set; }

        private static BankInteractor bankInteractor;
        
        public static void Initialize(BankInteractor interactor) {
            bankInteractor = interactor;
            isInitialized = true;
            OnBankInitializedEvent?.Invoke();
        }

        public static void IsEnoughCoins(int value) {
            CheckClass();
            bankInteractor.IsEnoughCoins(value);
        }

        public static void AddCoins(object sender, int value) {
            CheckClass();
            bankInteractor.AddCoins(sender, value);
            SendMessage();
        }

        public static void Spend(object sender, int value) {
            IsEnoughCoins(value);
            bankInteractor.Spend(sender, value);
            SendMessage();
        }
        
        public static void Reset(object sender) {
            CheckClass();
            bankInteractor.Reset(sender);
            SendMessage();
        }

        public static void SendMessage() {
            OnBankChangeBalanceEvent?.Invoke();
        }

        private static void CheckClass() {
            if (!isInitialized)
                throw new Exception("Bank is not initialize yet");
        }
    }
}