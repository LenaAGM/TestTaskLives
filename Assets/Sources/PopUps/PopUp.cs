using System.Linq;
using System.Threading.Tasks;
using Sources.Domain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.PopUps
{
    public sealed class PopUp : MonoBehaviour
    {
        public PopUpModel PopUpModel;
        
        [SerializeField] private UIManager UIManager;
        
        [SerializeField] private Image Shadow;
        
        [SerializeField] private RectTransform Root;
        
        [SerializeField] private TextMeshProUGUI TitleText;

        [SerializeField] private GameObject BlockInput;

        [SerializeField] private PopUpItem[] PopUpItems;

        public void SubscribeActions()
        {
            var livesPopUp = GetLivesPopUp();
            if (livesPopUp != null)
            {
                livesPopUp.UseLifeAction += PopUpModel.PlayerData.ReduceLives;
                livesPopUp.RefillLivesAction += PopUpModel.PlayerData.SetFullLives;
                
                livesPopUp.UseLifeAction += UpdateLivesPopUpUI;
                livesPopUp.RefillLivesAction += UpdateLivesPopUpUI;
            }
        }

        public LivesPopUp GetLivesPopUp()
        {
            var livesPopUp = PopUpItems.First(item => item.GetType() == typeof(LivesPopUp));
            return livesPopUp != null ? (LivesPopUp)livesPopUp : null;
        }

        public void UpdateLivesPopUpUI()
        {
            UIManager.LivesPopUpRepaint(PopUpModel.PlayerData.Lives);
        }
        
        public void UpdateRootPosition(float x)
        {
            Root.localPosition = new Vector3(x, 0f, 0f);
        }
        
        public void UpdateShadowAlpha(float val)
        {
            Shadow.color = new Color(0, 0, 0, val);
        }

        public async void Open<T>() where T : PopUpItem
        {
            UpdateRootPosition(-2000f);
            
            gameObject.SetActive(true);
            foreach (var popUp in PopUpItems)
            {
                if (popUp.GetType() == typeof(T))
                {
                    TitleText.text = popUp.Title;
                }
                popUp.gameObject.SetActive(popUp.GetType() == typeof(T));
            }
            
            BlockInput.SetActive(true);

            iTween.ValueTo(gameObject,iTween.Hash("from",-2000f,"to",0f,"time",2,"onupdate","UpdateRootPosition"));
            iTween.ValueTo(gameObject,iTween.Hash("from",0f,"to",0.5f,"time",2,"onupdate","UpdateShadowAlpha"));

            await Task.Delay(2000);
            
            BlockInput.SetActive(false);
        }
        
        public async void Close()
        {
            BlockInput.SetActive(true);

            iTween.ValueTo(gameObject,iTween.Hash("from",0f,"to",-2000f,"time",2,"onupdate","UpdateRootPosition"));
            iTween.ValueTo(gameObject,iTween.Hash("from",0.5f,"to",0,"time",2,"onupdate","UpdateShadowAlpha"));

            await Task.Delay(2000);
            
            gameObject.SetActive(false);
        }
    }
}