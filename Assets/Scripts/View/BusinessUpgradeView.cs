using Game.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class BusinessUpgradeView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI upgradeName;
        [Space]
        [SerializeField] private TextMeshProUGUI factor;
        [SerializeField] private string factorFormat;
        [Space]
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private string priceFormat;
        [Space]
        [SerializeField] private GameObject priceContainer;
        [SerializeField] private GameObject boughtContainer;

        private string upgradeId;

        public delegate void Click(string businessId);
        public event Click OnClick;

        public void Init(ref BusinessUpgradeComponent businessUpgrade)
        {
            upgradeId = businessUpgrade.Id;
            upgradeName.text = businessUpgrade.Name;
            factor.text = string.Format(factorFormat, businessUpgrade.Factor * 100);
            price.text = string.Format(priceFormat, businessUpgrade.Price);

            button.onClick.AddListener(InvokeClick);
        }

        public void SetBoughtState()
        {           
            button.onClick.RemoveListener(InvokeClick);          

            priceContainer.SetActive(false);
            boughtContainer.SetActive(true);
        }

        private void InvokeClick()
        {
            OnClick?.Invoke(upgradeId);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(InvokeClick);
        }
    }
}
