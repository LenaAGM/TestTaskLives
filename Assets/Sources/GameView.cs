using Sources.Components;
using Sources.Domain;
using Sources.PopUps;
using UnityEngine;

namespace Sources
{
    public sealed class GameView : MonoBehaviour
    {
        public GameModel GameModel;
        
        [SerializeField] private UIManager UIManager;

        [SerializeField] private LivesComponent LivesComponent;
        
        public PopUp PopUp;

        public void Init()
        {
            UIManager.Init();
            UIManager.LivesPopUpRepaint(GameModel.PlayerData.Lives);
        }

        public void UpdateUI()
        {
            var lives = GameModel.PlayerData.Lives;
            var timeToLifeGeneration = GameModel.GetTimeToLifeGeneration();
            LivesComponent.RepaintUI(lives, timeToLifeGeneration == "" ? "Full" : timeToLifeGeneration);
            PopUp.GetLivesPopUp()?.LivesComponent.RepaintUI(lives, timeToLifeGeneration);
            PopUp.UpdateLivesPopUpUI();
        }
    }
}