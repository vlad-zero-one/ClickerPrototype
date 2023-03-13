using Game.Configs;

namespace Game
{
    public class BusinessUpgrade
    {
        private BusinessUpgradeData data;
        private string name;

        public string Name => name;
        public double Price => data.Price;
        public float Factor => data.Factor;

        public bool Bought { get; private set; }

        public BusinessUpgrade(BusinessUpgradeData data, string name)
        {
            this.data = data;
            this.name = name;
        }

        public void Buy()
        {
            Bought = true;
        }
    }
}
