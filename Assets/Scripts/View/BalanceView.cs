using TMPro;
using UnityEngine;

namespace Game.View
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI balanceValue;
        [SerializeField] private string format;

        public void SetValue(double value)
        {
            balanceValue.text = string.Format(format, value);
        }
    }
}
