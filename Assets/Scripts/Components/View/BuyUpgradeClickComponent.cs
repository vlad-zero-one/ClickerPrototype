namespace Game.Components
{
    public struct BuyUpgradeClickComponent
    {
        public Business Business;
        public BusinessUpgrade BusinessUpgrade;
    }

    public struct NewBuyUpgradeClickComponent
    {
        public string BusinessId;
        public string BusinessUpgradeId;
    }
}