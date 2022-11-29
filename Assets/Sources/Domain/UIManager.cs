using Sources.Data;
using UnityEngine;

namespace Sources.Domain
{
    public sealed class UIManager : MonoBehaviour
    {
        private float BackgroundPopUpHeight;
        private float BackgroundPopUpWidth;
        private float BackgroundPopUpScale;

        #region PopUps Variables

        [SerializeField] private RectTransform BackgroundPopUpRectTransform;
        [SerializeField] private RectTransform ClosePopUpButtonRectTransform;

        #endregion
        
        #region DailyBonusPopUp Variables

        [SerializeField] private RectTransform ClaimCoinsButtonRectTransform;

        #endregion

        #region LivesPopUp Variables

        [SerializeField] private RectTransform UseLifeButtonRectTransform;
        [SerializeField] private RectTransform RefillLivesButtonRectTransform;

        #endregion

        public void Init()
        {
            SetStartValues();
            PopUpsRepaint();
            DailyBonusPopUpRepaint();
        }

        private void SetStartValues()
        {
            var backgroundPopUpStartWidth = 270f;
            var backgroundPopUpStartHeight = 300f;
            BackgroundPopUpHeight = BackgroundPopUpRectTransform.rect.height;
            BackgroundPopUpScale = BackgroundPopUpHeight / backgroundPopUpStartHeight;
            BackgroundPopUpWidth = BackgroundPopUpScale * backgroundPopUpStartWidth;
        }

        private void PopUpsRepaint()
        {
            BackgroundPopUpRectTransform.sizeDelta = new Vector2 (BackgroundPopUpWidth, BackgroundPopUpRectTransform.sizeDelta.y);;
            
            ClosePopUpButtonRectTransform.transform.localPosition = new Vector3(
                BackgroundPopUpWidth / 2f - BackgroundPopUpScale * 14f,
                BackgroundPopUpHeight / 2 - BackgroundPopUpScale * 60f, 0);
            ClosePopUpButtonRectTransform.transform.localScale =
                new Vector3(BackgroundPopUpScale / 1.8f, BackgroundPopUpScale / 1.8f, 0);
        }

        public void DailyBonusPopUpRepaint()
        {
            ClaimCoinsButtonRectTransform.transform.localPosition = new Vector3(
                0, -BackgroundPopUpHeight / 2 + BackgroundPopUpScale * 75, 0);
            ClaimCoinsButtonRectTransform.transform.localScale =
                new Vector3(BackgroundPopUpScale / 2.2f, BackgroundPopUpScale / 2.2f, 0);
        }

        public void LivesPopUpRepaint(int countLives)
        {
            UseLifeButtonRectTransform.gameObject.SetActive(countLives > 0);
            RefillLivesButtonRectTransform.gameObject.SetActive(countLives < ProfileData.MAX_LIVES);

            var UseLifeButtonLocalScale = BackgroundPopUpScale / (countLives == ProfileData.MAX_LIVES ? 2.2f : 2.8f);
            var RefillLivesButtonLocalScale = BackgroundPopUpScale / (countLives == 0 ? 2.2f : 2.8f);
            
            UseLifeButtonRectTransform.transform.localPosition = new Vector3(
                0, -BackgroundPopUpHeight / 2 + BackgroundPopUpScale * (countLives == ProfileData.MAX_LIVES ? 75 : 90f), 0);
            UseLifeButtonRectTransform.transform.localScale =
                new Vector3(UseLifeButtonLocalScale, UseLifeButtonLocalScale, 0);
            
            RefillLivesButtonRectTransform.transform.localPosition = new Vector3(
                0, -BackgroundPopUpHeight / 2 + BackgroundPopUpScale * (countLives == 0 ? 75 : 40f), 0);
            RefillLivesButtonRectTransform.transform.localScale =
                new Vector3(RefillLivesButtonLocalScale, RefillLivesButtonLocalScale, 0);
        }
    }
}