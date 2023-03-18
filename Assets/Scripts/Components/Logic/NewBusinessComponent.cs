using Game.Configs;
using Game.Save;
using System.Collections.Generic;

namespace Game.Components
{
    public struct NewBusinessComponent
    {
        public NewBusinessUpgradeComponent FirstUpgrade;
        public NewBusinessUpgradeComponent SecondUpgrade;

        private readonly BusinessData data;
        private readonly BusinessNamesData namesData;

        private Dictionary<string, NewBusinessUpgradeComponent> upgrades;

        public NewBusinessComponent(BusinessData data, BusinessNamesData namesData)
        {
            this.data = data;
            this.namesData = namesData;

            Level = 0;

            upgrades = new();

            FirstUpgrade = new(data.FirstUpgradeData, namesData.FirstUpgradeName);
            SecondUpgrade = new(data.SecondUpgradeData, namesData.SecondUpgradeName);

            upgrades.Add(FirstUpgrade.Id, FirstUpgrade);
            upgrades.Add(SecondUpgrade.Id, SecondUpgrade);
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

                if (FirstUpgrade.Id == upgradeId) FirstUpgrade.Bought = true;
                if (SecondUpgrade.Id == upgradeId) SecondUpgrade.Bought = true;
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
            if (saveData.FirstUpgradeBought) FirstUpgrade.Bought = true;
            if (saveData.SecondUpgradeBought) SecondUpgrade.Bought = true;
        }

        private double Factors()
        {
            return (FirstUpgrade.Bought ? FirstUpgrade.Factor : 0) + (SecondUpgrade.Bought ? SecondUpgrade.Factor : 0);
        }
    }
}