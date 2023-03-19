using Game.Components;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI businessName;
        [SerializeField] private Slider progressBar;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI incomeText;
        [Space]
        [SerializeField] private Button levelUpButton;
        [SerializeField] private TextMeshProUGUI levelUpPrice;
        [Space]
        [SerializeField] private BusinessUpgradeView upgradePrefab;
        [SerializeField] private RectTransform upgradeParent;
        [Space]
        [SerializeField] private string priceFormat;

        private string businessId;
        private float incomeTime;

        private Dictionary<string, BusinessUpgradeView> upgradeViews;

        public delegate void LevelUpClick(string businessId);
        public delegate void UpgradeClick(string businessId, string businessUpgradeId);

        public event LevelUpClick OnLevelUpClick;
        public event UpgradeClick OnBuyUpgradeClick;

        public void Init(ref BusinessComponent business)
        {
            businessId = business.Id;
            incomeTime = business.IncomeTime;

            businessName.text = business.Name;

            upgradeViews = new();
            foreach (var upgrade in business.Upgrades)
            {
                var upgradeView = Instantiate(upgradePrefab, upgradeParent);
                upgradeView.Init(upgrade);
                upgradeView.OnClick += BuyUpgrade;
                upgradeViews.Add(upgrade.Id, upgradeView);
            }

            UpdateView(ref business);

            levelUpButton.onClick.AddListener(InvokeClick);
        }

        public void UpdateView(ref BusinessComponent business)
        {
            levelText.text = business.Level.ToString();
            incomeText.text = string.Format(priceFormat, business.Income);
            levelUpPrice.text = string.Format(priceFormat, business.LevelUpPrice);

            foreach (var upgrade in business.Upgrades)
            {
                if (upgrade.Bought)
                {
                    if (upgradeViews.TryGetValue(upgrade.Id, out var view))
                    {
                        view.SetBoughtState();
                    }
                }
            }
        }

        public void SetProgress(float progress)
        {
            progressBar.value = progress / incomeTime;
        }

        private void BuyUpgrade(string businessUpgradeId)
        {
            OnBuyUpgradeClick?.Invoke(businessId, businessUpgradeId);
        }

        private void InvokeClick()
        {
            OnLevelUpClick?.Invoke(businessId);
        }

        private void OnDestroy()
        {
            levelUpButton.onClick.RemoveListener(InvokeClick);

            foreach (var upgrade in upgradeViews.Values)
            {
                upgrade.OnClick -= BuyUpgrade;
            }
        }
    }
}
