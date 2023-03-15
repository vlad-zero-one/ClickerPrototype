using Game.Components;
using Game.View;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class UpdateBusinessViewSystem : IEcsRunSystem
    {
        private readonly BusinessViewsController businessViewController;

        private readonly EcsFilter<UpdateBusinessComponent> filter;

        private readonly EcsFilter<NewUpdateBusinessComponent, NewBusinessComponent> newFilter;


        public void Run()
        {
            foreach(var i in filter)
            {
                var business = filter.Get1(i).Business;
                ref var entity = ref filter.GetEntity(i);

                businessViewController.UpdateView(business);

                entity.Del<UpdateBusinessComponent>();
            }

            foreach (var i in newFilter)
            {
                ref var business = ref newFilter.Get2(i);
                ref var entity = ref filter.GetEntity(i);

                businessViewController.UpdateView(business.Id);

                entity.Del<NewUpdateBusinessComponent>();
            }
        }
    }
}