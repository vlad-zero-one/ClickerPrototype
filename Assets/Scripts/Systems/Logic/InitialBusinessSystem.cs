using Leopotam.Ecs;
using Game.Configs;
using Game.Components;

namespace Game.Systems
{
    public class InitialBusinessSystem : IEcsInitSystem
    {
        private readonly BusinessesConfig businessesConfig;

        private readonly EcsFilter<NewBusinessComponent> newProgressFilter;

        public void Init()
        {
            foreach (var i in newProgressFilter)
            {
                ref var business = ref newProgressFilter.Get1(i);

                if (business.Id != businessesConfig.InitialBusinessId)
                {
                    continue;
                }

                business.LevelUp();

                newProgressFilter.GetEntity(i).Get<ProgressComponent>();
            }
        }
    }
}