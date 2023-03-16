using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class LevelUpSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld;

        //private readonly BusinessesManager businessesManager;

        private readonly BalanceManager balanceManager;

        //private readonly EcsFilter<LevelUpClickComponent> filter;

        private readonly EcsFilter<LevelUpClickComponent, NewBusinessComponent> newFilter;

        public void Run()
        {
            //foreach (var i in filter)
            //{
            //    var business = filter.Get1(i).Business;
            //    ref var levelUpEntity = ref filter.GetEntity(i);

            //    if (businessesManager.LevelUp(business))
            //    {
            //        if (business.Level == 1)
            //        {
            //            var startProgressEntity = ecsWorld.NewEntity();
            //            startProgressEntity.Get<ProgressComponent>();
            //            startProgressEntity.Get<BusinessComponent>().Business = business;
            //        }

            //        levelUpEntity.Get<UpdateBusinessComponent>().Business = business;

            //        levelUpEntity.Get<UpdateBalanceComponent>();
            //    }

            //    levelUpEntity.Del<LevelUpClickComponent>();
            //}

            foreach (var i in newFilter)
            {
                ref var levelUpEntity = ref newFilter.GetEntity(i);
                ref var business = ref newFilter.Get2(i);

                if (balanceManager.Spend(business.LevelUpPrice))
                {
                    business.LevelUp();

                    if (business.Level == 1)
                    {
                        levelUpEntity.Get<ProgressComponent>();
                    }

                    levelUpEntity.Get<NewUpdateBusinessComponent>();

                    levelUpEntity.Get<UpdateBalanceComponent>();
                }

                levelUpEntity.Del<LevelUpClickComponent>();
            }
        }
    }
}