using System;
using Sources.Components;

namespace Sources.PopUps
{
    public class LivesPopUp : PopUpItem
    {
        public LivesComponent LivesComponent;
        
        public Action UseLifeAction;
        public Action RefillLivesAction;

        public void UseLife()
        {
            UseLifeAction.Invoke();
        }
        
        public void RefillLives()
        {
            RefillLivesAction.Invoke();
        }
    }
}