using Game.Components;
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

        private string businessId;
        private float incomeTime;

        public delegate void LevelUpClick(string businessId);
        public delegate void UpgradeClick(string businessId, string businessUpgradeId);

        public event LevelUpClick OnLevelUpClick;
        public event UpgradeClick OnBuyUpgradeClick;

        public void Init(ref BusinessComponent business)
        {
            businessId = business.Id;
            incomeTime = business.IncomeTime;

            firstUpgrade.Init(ref business.FirstUpgrade);
            secondUpgrade.Init(ref business.SecondUpgrade);

            businessName.text = business.Name;

            UpdateView(ref business);

            levelUpButton.onClick.AddListener(InvokeClick);
            firstUpgrade.OnClick += BuyUpgrade;
            secondUpgrade.OnClick += BuyUpgrade;
        }

        public void UpdateView(ref BusinessComponent business)
        {
            levelText.text = business.Level.ToString();
            incomeText.text = string.Format(priceFormat, business.Income);
            levelUpPrice.text = string.Format(priceFormat, business.LevelUpPrice);

            if (business.FirstUpgrade.Bought) firstUpgrade.SetBoughtState();
            if (business.SecondUpgrade.Bought) secondUpgrade.SetBoughtState();
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
            firstUpgrade.OnClick -= BuyUpgrade;
            secondUpgrade.OnClick -= BuyUpgrade;
        }
    }
}
