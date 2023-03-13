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
        [SerializeField] private BusinessUpgradeView firstUpgrade;
        [SerializeField] private BusinessUpgradeView secondUpgrade;
        [Space]
        [SerializeField] private string priceFormat;

        private Business business;

        public delegate void LevelUpClick(Business business);
        public delegate void UpgradeClick(Business business, BusinessUpgrade businessUpgrade);

        public event LevelUpClick OnLevelUpClick;
        public event UpgradeClick OnBuyUpgradeClick;

        public void Init(Business business)
        {
            this.business = business;

            firstUpgrade.Init(business.firstUpgrade);
            secondUpgrade.Init(business.secondUpgrade);

            UpdateView();

            levelUpButton.onClick.AddListener(InvokeClick);
            firstUpgrade.OnClick += BuyUpgrade;
            secondUpgrade.OnClick += BuyUpgrade;
        }

        public void UpdateView()
        {
            businessName.text = business.Name;
            levelText.text = business.Level.ToString();
            incomeText.text = string.Format(priceFormat, business.Income);
            levelUpPrice.text = string.Format(priceFormat, business.LevelUpPrice);

            firstUpgrade.UpdateView();
            secondUpgrade.UpdateView();
        }

        public void SetProgress(float progress)
        {
            progressBar.value = progress / business.IncomeTime;
        }

        private void BuyUpgrade(BusinessUpgrade businessUpgrade)
        {
            OnBuyUpgradeClick?.Invoke(business, businessUpgrade);
        }

        private void InvokeClick()
        {
            OnLevelUpClick?.Invoke(business);
        }

        private void OnDestroy()
        {
            levelUpButton.onClick.RemoveListener(InvokeClick);
            firstUpgrade.OnClick -= BuyUpgrade;
            secondUpgrade.OnClick -= BuyUpgrade;
        }
    }
}
