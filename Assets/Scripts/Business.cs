using Game.Configs;
using Game.Save;

namespace Game
{
    public class Business
    {
        public BusinessUpgrade firstUpgrade;
        public BusinessUpgrade secondUpgrade;

        private BusinessData data;
        private BusinessNamesData namesData;

        public Business(BusinessData data, BusinessNamesData namesData)
        {
            this.data = data;
            this.namesData = namesData;

            firstUpgrade = new(data.FirstUpgradeData, namesData.FirstUpgradeName);
            secondUpgrade = new(data.SecondUpgradeData, namesData.SecondUpgradeName);
        }

        public string Id => data.Id;
        public string Name => namesData.BusinessName;
        public double Income => Level * data.BaseIncome * (1 + factors);
        public float IncomeTime => data.IncomeTime;
        public double LevelUpPrice => (Level + 1) * data.BaseLevelUpPrice;
        public int Level { get; private set; }

        private double factors => (firstUpgrade.Bought ? firstUpgrade.Factor : 0) + (secondUpgrade.Bought ? secondUpgrade.Factor : 0);

        public void LevelUp()
        {
            ++Level;
        }

        public void FromLoad(SaveDataBusiness saveData)
        {
            Level = saveData.Level;
            if (saveData.FirstUpgradeBought) firstUpgrade.Buy();
            if (saveData.SecondUpgradeBought) secondUpgrade.Buy();
        }
    }
}
