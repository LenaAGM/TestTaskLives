using TMPro;
using UnityEngine;

namespace Sources.Components
{
    public class LivesComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI CountText;
        [SerializeField] private TextMeshProUGUI TimeText;
        
        public void RepaintUI(int count, string time)
        {
            CountText.text = count.ToString();
            TimeText.text = time;
        }
    }
}