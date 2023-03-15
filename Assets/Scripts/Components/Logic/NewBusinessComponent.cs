using Game.Configs;
using Game.Save;

namespace Game.Components
{
    public struct NewBusinessComponent
    {
        public readonly NewBusinessUpgradeComponent FirstUpgrade;
        public readonly NewBusinessUpgradeComponent SecondUpgrade;

        private readonly BusinessData data;
        private readonly BusinessNamesData namesData;

        public NewBusinessComponent(BusinessData data, BusinessNamesData namesData)
        {
            this.data = data;
            this.namesData = namesData;

            Level = 0;

            FirstUpgrade = new(data.FirstUpgradeData, namesData.FirstUpgradeName);
            SecondUpgrade = new(data.SecondUpgradeData, namesData.SecondUpgradeName);
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

        public void FromLoad(SaveDataBusiness saveData)
        {
            Level = saveData.Level;
            if (saveData.FirstUpgradeBought) FirstUpgrade.Buy();
            if (saveData.SecondUpgradeBought) SecondUpgrade.Buy();
        }

        private double Factors()
        {
            return (FirstUpgrade.Bought ? FirstUpgrade.Factor : 0) + (SecondUpgrade.Bought ? SecondUpgrade.Factor : 0);
        }
    }
}