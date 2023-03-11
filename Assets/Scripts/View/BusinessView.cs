using System.Collections;
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
        [SerializeField] private BusinessUpgradeView firstUpgrade;
        [SerializeField] private BusinessUpgradeView secondUpgrade;
        [Space]
        [SerializeField] private string priceFormat;

        private void Start()
        {
            var conf = new Configs.BusinessUpgradeData();
            conf.Price = 1;
            conf.Factor = 0.5f;

            var bu = new BusinessUpgrade(conf, "New Name");

            firstUpgrade.Init(bu);
            firstUpgrade.OnClick += () => Debug.LogError("!");
        }

        public void Init(Business business)
        {
            businessName.SetText(business.Name);
            levelText.SetText(business.Level.ToString());
            incomeText.SetText(priceFormat, (float)business.Income);
            levelUpPrice.SetText(priceFormat, (float)business.LevelUpPrice);

            firstUpgrade.Init(business.firstUpgrade);
            secondUpgrade.Init(business.secondUpgrade);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
            }
        }
    }
}
