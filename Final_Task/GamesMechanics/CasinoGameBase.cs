
namespace Final_Task.GamesMechanics
{
    internal abstract class CasinoGameBase
    {
        protected CasinoGameBase() 
        {
            FactoryMethod();
        }

        public abstract void PlayGame();
        protected abstract void FactoryMethod();

        public event Action OnWin;
        public event Action OnLoose;
        public event Action OnDraw;

        protected void OnWinInvoke()
        {
            OnWin?.Invoke();
        }

        protected void OnLooseInvoke()
        {
            OnLoose?.Invoke();
        }

        protected void OnDrawInvoke()
        {
            OnDraw?.Invoke();
        }
        
    }
}
