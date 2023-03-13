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

        public delegate void Click(Business business);
        public event Click OnLevelUpClick;

        public void Init(Business business)
        {
            this.business = business;

            UpdateView();

            firstUpgrade.Init(business.firstUpgrade);
            secondUpgrade.Init(business.secondUpgrade);

            levelUpButton.onClick.AddListener(InvokeClick);
        }

        public void UpdateView()
        {
            businessName.text = business.Name;
            levelText.text = business.Level.ToString();
            incomeText.text = string.Format(priceFormat, business.Income);
            levelUpPrice.text = string.Format(priceFormat, business.LevelUpPrice);
        }

        private void Start()
        {
            firstUpgrade.OnClick += () => Debug.LogError("!");
        }

        private void InvokeClick()
        {
            OnLevelUpClick?.Invoke(business);
        }

        private void OnDestroy()
        {
            levelUpButton.onClick.RemoveListener(InvokeClick);
        }
    }
}
