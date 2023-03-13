using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
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

        public delegate void Click();
        public event Click OnClick;

        public void Init(BusinessUpgrade businessUpgrade)
        {
            this.businessUpgrade = businessUpgrade;

            upgradeName.text = businessUpgrade.Name;
            factor.text = string.Format(factorFormat, businessUpgrade.Factor);
            price.text = string.Format(priceFormat, businessUpgrade.Price);

            button.onClick.AddListener(InvokeClick);
        }

        public void Buy()
        {
            priceContainer.SetActive(false);
            boughtContainer.SetActive(true);
        }

        private void InvokeClick()
        {
            OnClick?.Invoke();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(InvokeClick);
        }
    }
}
