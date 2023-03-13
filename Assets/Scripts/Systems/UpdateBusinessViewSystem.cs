using Game.Components;
using Game.View;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class UpdateBusinessViewSystem : IEcsRunSystem
    {
        private readonly BusinessViewsController businessViewController;

        private readonly EcsFilter<UpdateBusinessComponent> filter;
        
        public void Run()
        {
            foreach(var i in filter)
            {
                var business = filter.Get1(i).Business;
                ref var entity = ref filter.GetEntity(i);

                businessViewController.UpdateView(business);

                entity.Del<UpdateBusinessComponent>();
            }
        }
    }
}