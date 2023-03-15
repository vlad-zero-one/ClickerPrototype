using Game.Configs;

namespace Game.Components
{
    public struct NewBusinessUpgradeComponent
    {
        private readonly BusinessUpgradeData data;
        private readonly string name;

        public NewBusinessUpgradeComponent(BusinessUpgradeData data, string name)
        {
            this.data = data;
            this.name = name;

            Bought = false;
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