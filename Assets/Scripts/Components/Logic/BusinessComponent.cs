using Game.Configs;
using Game.Save;
using System.Collections.Generic;
using System.Linq;

namespace Game.Components
{
    public struct BusinessComponent
    {
        private readonly BusinessData data;
        private readonly BusinessNamesData namesData;

        private readonly Dictionary<string, BusinessUpgrade> upgrades;

        public List<BusinessUpgrade> Upgrades => upgrades.Values.ToList();

        public BusinessComponent(BusinessData data, BusinessNamesData namesData)
        {
            this.data = data;
            this.namesData = namesData;

            Level = 0;

            upgrades = new();

            foreach(var upgrade in data.UpgradeDatas)
            {
                if (namesData.UpgradeNames.TryGetValue(upgrade.Id, out var name))
                {
                    var upgradeComponent = new BusinessUpgrade(upgrade, name);

                    upgrades.Add(upgrade.Id, upgradeComponent);
                }
            }
        }

        public string Id => data.Id;
        public string Name => namesData.BusinessName;
        public double Income => Level * data.BaseIncome * (1 + Factors());
        public float IncomeTime => data.IncomeTime;
        public double LevelUpPrice => (Level + 1) * data.BaseLevelUpPrice;
        public int Level { get; private set; }

        public void LevelUp()
        {
            ++Level;
        }

        public void BuyUpgrade(string upgradeId)
        {
            if (upgrades.TryGetValue(upgradeId, out var upgrade))
            {
                upgrade.Bought = true;
            }
        }

        public bool HasUpgrade(string upgradeId)
        {
            return upgrades.ContainsKey(upgradeId);
        }

        public double GetUpgradePrice(string upgradeId)
        {
            if (upgrades.TryGetValue(upgradeId, out var upgrade))
            {
                return upgrade.Price;
            }

            return 0;
        }

        public void FromLoad(SaveDataBusiness saveData)
        {
            Level = saveData.Level;

            foreach(var upgrageData in saveData.IsUpgradeBought)
            {
                if (upgrades.ContainsKey(upgrageData.Key))
                {
                    var upgrade = upgrades[upgrageData.Key];
                    upgrade.Bought = upgrageData.Value;
                }
            }
        }

        private double Factors()
        {
            return upgrades.Values.Where(upgrade => upgrade.Bought).Sum(upgrade => upgrade.Factor);
        }
    }
}