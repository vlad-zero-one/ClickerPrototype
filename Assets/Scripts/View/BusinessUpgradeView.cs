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

        public delegate void Click();
        public event Click OnClick;

        public void Init(BusinessUpgrade businessUpgrade)
        {
            upgradeName.SetText(businessUpgrade.Name);
            factor.SetText(factorFormat, businessUpgrade.Factor);
            price.SetText(priceFormat, (float)businessUpgrade.Price);

            button.onClick.AddListener(InvokeClick);
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
