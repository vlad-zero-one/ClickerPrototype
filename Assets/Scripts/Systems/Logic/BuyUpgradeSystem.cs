using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class BuyUpgradeSystem : IEcsRunSystem
    {
        //private readonly BusinessesManager businessesManager;

        //private readonly EcsFilter<BuyUpgradeClickComponent> filter;

        private readonly BalanceManager balanceManager;

        private readonly EcsFilter<BuyUpgradeClickComponent, NewBusinessComponent, NewBusinessUpgradeComponent> newFilter;

        public void Run()
        {
            //foreach(var i in filter)
            //{
            //    ref var comp = ref filter.Get1(i);
            //    var business = comp.Business;
            //    var upgrade = comp.BusinessUpgrade;

            //    ref var entity = ref filter.GetEntity(i);

            //    if (businessesManager.BuyUpgrade(business, upgrade))
            //    {
            //        entity.Get<UpdateBusinessComponent>().Business = business;

            //        entity.Get<UpdateBalanceComponent>();
            //    }

            //    entity.Del<BuyUpgradeClickComponent>();
            //}

            foreach (var i in newFilter)
            {
                ref var entity = ref newFilter.GetEntity(i);
                ref var business = ref newFilter.Get2(i);
                ref var upgrade = ref newFilter.Get3(i);

                if (balanceManager.Spend(upgrade.Price))
                {
                    business.BuyUpgrade(upgrade.Id);

                    entity.Get<NewUpdateBusinessComponent>();

                    entity.Get<UpdateBalanceComponent>();
                }

                entity.Del<BuyUpgradeClickComponent>();
            }
        }
    }
}