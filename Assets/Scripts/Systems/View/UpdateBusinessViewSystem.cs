using Game.Components;
using Game.View;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class UpdateBusinessViewSystem : IEcsRunSystem
    {
        private readonly BusinessViewsController businessViewController;

        private readonly EcsFilter<NewUpdateBusinessComponent, NewBusinessComponent> newFilter;


        public void Run()
        {
            foreach (var i in newFilter)
            {
                ref var business = ref newFilter.Get2(i);
                ref var entity = ref newFilter.GetEntity(i);

                businessViewController.UpdateView(ref business);

                entity.Del<NewUpdateBusinessComponent>();
            }
        }
    }
}