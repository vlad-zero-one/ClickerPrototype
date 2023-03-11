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
        [SerializeField] private TextMeshProUGUI factor;
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private GameObject priceContainer;
        [SerializeField] private GameObject boughtContainer;

        public delegate void Click();
        public event Click OnClick;

        public void Init()
        {
            button.onClick.AddListener(OnClick.Invoke);
        }
    }
}
