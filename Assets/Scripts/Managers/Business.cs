using Game.Configs;
using Game.Save;

namespace Game
{
    public class Business
    {
        public readonly BusinessUpgrade FirstUpgrade;
        public readonly BusinessUpgrade SecondUpgrade;

        private readonly BusinessData data;
        private readonly BusinessNamesData namesData;

        public Business(BusinessData data, BusinessNamesData namesData)
        {
            this.data = data;
            this.namesData = namesData;

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
