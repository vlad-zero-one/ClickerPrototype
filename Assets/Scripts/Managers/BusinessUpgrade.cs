using Game.Configs;

namespace Game
{
    public class BusinessUpgrade
    {
        private readonly BusinessUpgradeData data;
        private readonly string name;

        public BusinessUpgrade(BusinessUpgradeData data, string name)
        {
            this.data = data;
            this.name = name;
        }

        public string Name => name;
        public double Price => data.Price;
        public float Factor => data.Factor;
        public bool Bought { get; private set; }

        public void Buy()
        {
            Bought = true;
        }
    }
}
