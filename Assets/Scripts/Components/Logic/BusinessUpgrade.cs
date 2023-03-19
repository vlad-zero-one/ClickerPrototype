using Game.Configs;

namespace Game.Components
{
    public class BusinessUpgrade
    {
        private readonly BusinessUpgradeData data;
        private readonly string name;

        public BusinessUpgrade(BusinessUpgradeData data, string name)
        {
            this.data = data;
            this.name = name;

            Bought = false;
        }

        public string Id => data.Id;
        public string Name => name;
        public double Price => data.Price;
        public float Factor => data.Factor;
        public bool Bought { get; set; }
    }
}