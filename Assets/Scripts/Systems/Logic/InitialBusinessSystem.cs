using Leopotam.Ecs;
using Game.Configs;
using Game.Components;

namespace Game.Systems
{
    public class InitialBusinessSystem : IEcsInitSystem
    {
        private readonly BusinessesConfig businessesConfig;

        private readonly EcsFilter<BusinessComponent> filter;

        public void Init()
        {
            foreach (var i in filter)
            {
                ref var business = ref filter.Get1(i);

                if (business.Id != businessesConfig.InitialBusinessId)
                {
                    continue;
                }

                business.LevelUp();

                filter.GetEntity(i).Get<ProgressComponent>();
            }
        }
    }
}