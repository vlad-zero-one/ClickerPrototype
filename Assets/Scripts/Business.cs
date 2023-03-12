using Game.Configs;

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

        public string Name => namesData.BusinessName;
        public int Level { get; private set; }
        public double Income => Level * data.BaseIncome * (1 + firstUpgrade.Factor + secondUpgrade.Factor);
        public float IncomeTime => data.IncomeTime;
        public double LevelUpPrice => (Level + 1) * data.BaseLevelUpPrice;

        public void LevelUp()
        {
            ++Level;
        }
    }
}
