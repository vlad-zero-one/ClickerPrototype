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

        private BusinessUpgrade businessUpgrade;

        public delegate void Click(BusinessUpgrade businessUpgrade);
        public event Click OnClick;

        public void Init(BusinessUpgrade businessUpgrade)
        {
            this.businessUpgrade = businessUpgrade;

            UpdateView();

            button.onClick.AddListener(InvokeClick);
        }

        public void UpdateView()
        {
            if (!businessUpgrade.Bought)
            {
                upgradeName.text = businessUpgrade.Name;
                factor.text = string.Format(factorFormat, businessUpgrade.Factor);
                price.text = string.Format(priceFormat, businessUpgrade.Price);

                priceContainer.SetActive(!businessUpgrade.Bought);
                boughtContainer.SetActive(businessUpgrade.Bought);
            }
            else
            {
                button.onClick.RemoveListener(InvokeClick);
            }
        }

        private void InvokeClick()
        {
            OnClick?.Invoke(businessUpgrade);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(InvokeClick);
        }
    }
}
