using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class LevelUpSystem : IEcsRunSystem
    {
        private readonly BalanceManager balanceManager;

        private readonly EcsFilter<LevelUpClickComponent> levelUpClickFilter;

        private readonly EcsFilter<BusinessComponent> businessFilter;

        public void Run()
        {
            foreach (var i in levelUpClickFilter)
            {
                foreach (var j in businessFilter)
                {
                    if (businessFilter.Get1(j).Id == levelUpClickFilter.Get1(i).BusinessId)
                    {
                        ref var businessEntity = ref businessFilter.GetEntity(j);
                        ref var business = ref businessFilter.Get1(j);

                        if (balanceManager.Spend(business.LevelUpPrice))
                        {
                            business.LevelUp();

                            if (business.Level == 1)
                            {
                                businessEntity.Get<ProgressComponent>();
                            }

                            businessEntity.Get<UpdateBusinessViewComponent>();

                            levelUpClickFilter.GetEntity(i).Get<UpdateBalanceViewComponent>();
                        }

                        break;
                    }
                }
            }
        }
    }
}