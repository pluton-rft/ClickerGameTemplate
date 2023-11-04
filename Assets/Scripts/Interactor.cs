namespace Clicker.Architecture {
    public abstract class Interactor {
        
        public virtual void OnCreate() { } // Когда все репо и интеракторы созданы.
        public virtual void Initialize() { } // Когда все репо и интеракторы выполнили OnCreate().
        public virtual void OnStart() { } // Когда все репо и интеракторы проинициализарованы.
    }
}

