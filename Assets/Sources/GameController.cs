using Sources.PopUps;
using UnityEngine;

namespace Sources
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameView GameView;
        
        private void Start()
        {
            GameView.GameModel = new GameModel();
            GameView.Init();
            InitPopUps();
            OpenDailyBonusPopUp();
        }
        
        private void Update()
        {
            GameView.UpdateUI();
        }

        private void InitPopUps()
        {
            GameView.PopUp.PopUpModel = new PopUpModel(GameView.GameModel.PlayerData);
            GameView.PopUp.SubscribeActions();
        }

        private void OpenDailyBonusPopUp()
        {
            GameView.PopUp.Open<DailyBonusPopUp>();
        }
        
        public void OpenLivesPopUp()
        {
            GameView.PopUp.Open<LivesPopUp>();
        }
    }
}