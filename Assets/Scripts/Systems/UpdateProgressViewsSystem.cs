using Leopotam.Ecs;
using Game.View;
using Game.Components;

namespace Game.Systems
{
    public class UpdateProgressViewsSystem : IEcsRunSystem
    {
        private readonly BusinessViewController businessViewController;

        private readonly EcsFilter<BusinessComponent, ProgressComponent> filter;
        
        public void Run()
        {
            foreach (var i in filter)
            {
                businessViewController.SetProgress(filter.Get1(i).Business, filter.Get2(i).Progress);
            }
        }
    }
}