using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class LevelUpSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly BusinessesManager businessesManager;

        private readonly EcsFilter<LevelUpClickComponent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                var business = filter.Get1(i).Business;
                ref var levelUpEntity = ref filter.GetEntity(i);

                if (businessesManager.LevelUp(business))
                {
                    if (business.Level == 1)
                    {
                        var startProgressEntity = ecsWorld.NewEntity();
                        startProgressEntity.Get<ProgressComponent>();
                        startProgressEntity.Get<BusinessComponent>().Business = business;
                    }

                    levelUpEntity.Get<UpdateBusinessComponent>().Business = business;

                    levelUpEntity.Get<UpdateBalanceComponent>();
                }

                levelUpEntity.Del<LevelUpClickComponent>();
            }
        }
    }
}