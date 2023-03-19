using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class BuyUpgradeSystem : IEcsRunSystem
    {
        private readonly BalanceManager balanceManager;

        private readonly EcsFilter<BuyUpgradeClickComponent> upgradeClickFilter;

        private readonly EcsFilter<BusinessComponent, ProgressComponent> businessFilter;

        public void Run()
        {
            foreach (var i in upgradeClickFilter)
            {
                foreach (var j in businessFilter)
                {
                    ref var upgradeComponent = ref upgradeClickFilter.Get1(i);
                    ref var business = ref businessFilter.Get1(j);
                    var upgradeId = upgradeComponent.BusinessUpgradeId;

                    if (upgradeComponent.BusinessId == business.Id && business.HasUpgrade(upgradeId))
                    {
                        if (balanceManager.Spend(business.GetUpgradePrice(upgradeId)))
                        {
                            business.BuyUpgrade(upgradeId);

                            businessFilter.GetEntity(j).Get<UpdateBusinessViewComponent>();

                            upgradeClickFilter.GetEntity(i).Get<UpdateBalanceViewComponent>();
                        }
                    }
                }
            }
        }
    }
}