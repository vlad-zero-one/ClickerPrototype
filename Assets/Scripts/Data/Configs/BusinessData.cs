using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
    [Serializable]
    public class BusinessData
    {
        [SerializeField] private string id;
        [Space]
        [SerializeField] private float incomeTime;
        [SerializeField] private double baseLevelUpPrice;
        [SerializeField] private double baseIncome;
        [Space]
        [SerializeField] private List<BusinessUpgradeData> upgradeDatas;

        public string Id => id;
        public float IncomeTime => incomeTime;
        public double BaseLevelUpPrice => baseLevelUpPrice;
        public double BaseIncome => baseIncome;
        public IReadOnlyList<BusinessUpgradeData> UpgradeDatas => upgradeDatas;
    }
}
