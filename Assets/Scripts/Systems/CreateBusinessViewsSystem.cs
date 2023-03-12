using Leopotam.Ecs;
using Game.Configs;
using System.Linq;
using Game.Components;
using Game.View;

namespace Game.Systems
{
    public class CreateBusinessViewsSystem : IEcsInitSystem
    {
        private readonly BusinessViewController businessViewController;

        private readonly EcsFilter<CreateBusinessViewComponent> filter;
        
        public void Init()
        {
            businessViewController.Init();

            foreach(var i in filter)
            {
                ref var comp = ref filter.Get1(i);

                businessViewController.Instantiate(comp.Business);
            }
        }
    }
}