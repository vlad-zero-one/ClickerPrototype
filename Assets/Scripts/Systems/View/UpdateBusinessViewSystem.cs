using Game.Components;
using Game.View;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class UpdateBusinessViewSystem : IEcsRunSystem
    {
        private readonly BusinessViewsController businessViewController;

        private readonly EcsFilter<BusinessComponent, UpdateBusinessViewComponent> newFilter;


        public void Run()
        {
            foreach (var i in newFilter)
            {
                ref var business = ref newFilter.Get1(i);

                businessViewController.UpdateView(ref business);
            }
        }
    }
}