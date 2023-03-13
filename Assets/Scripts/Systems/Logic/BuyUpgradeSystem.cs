using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class BuyUpgradeSystem : IEcsRunSystem
    {
        private readonly BusinessesManager businessesManager;

        private readonly EcsFilter<BuyUpgradeClickComponent> filter;
        
        public void Run()
        {
            foreach(var i in filter)
            {
                ref var comp = ref filter.Get1(i);
                var business = comp.Business;
                var upgrade = comp.BusinessUpgrade;

                ref var entity = ref filter.GetEntity(i);

                if (businessesManager.BuyUpgrade(business, upgrade))
                {
                    ref var updateComp = ref entity.Get<UpdateBusinessComponent>();
                    updateComp.Business = business;

                    entity.Get<UpdateBalanceComponent>();
                }

                entity.Del<BuyUpgradeClickComponent>();
            }
        }
    }
}