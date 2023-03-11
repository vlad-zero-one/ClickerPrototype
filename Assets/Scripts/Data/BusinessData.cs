using System;
using UnityEngine;

namespace Game.Configs
{
    [Serializable]
    public class BusinessData
    {
        public string Id;
        [Space]
        public float IncomeTime;
        public double BaseLevelUpPrice;
        public double BaseIncome;
        [Space]
        public BusinessUpgradeData FirstUpgradeData;
        public BusinessUpgradeData SecondUpgradeData;
    }
}
