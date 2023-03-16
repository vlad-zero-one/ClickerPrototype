using Leopotam.Ecs;
using Game.View;
using Game.Components;

namespace Game.Systems
{
    public class UpdateProgressViewsSystem : IEcsRunSystem
    {
        private readonly BusinessViewsController businessViewsController;

        private readonly EcsFilter<BusinessComponent, ProgressComponent> filter;

        private readonly EcsFilter<NewBusinessComponent, ProgressComponent> newFilter;

        public void Run()
        {
            //foreach (var i in filter)
            //{
            //    businessViewsController.SetProgress(filter.Get1(i).Business, filter.Get2(i).Progress);
            //}

            foreach (var i in newFilter)
            {
                businessViewsController.SetProgress(newFilter.Get1(i).Id, newFilter.Get2(i).Progress);
            }
        }
    }
}