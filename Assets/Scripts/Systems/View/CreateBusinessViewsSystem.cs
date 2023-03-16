using Leopotam.Ecs;
using Game.View;
using Game.Components;

namespace Game.Systems
{
    public class CreateBusinessViewsSystem : IEcsInitSystem
    {
        private readonly BusinessViewsController businessViewsController;

        //private readonly BusinessesManager businessesManager;

        private readonly EcsFilter<NewBusinessComponent> businessesFilter;

        public void Init()
        {
            //foreach (var business in businessesManager.Businesses.Values)
            //{
            //    businessViewsController.Instantiate(business);
            //}

            foreach (var i in businessesFilter)
            {
                businessViewsController.Instantiate(ref businessesFilter.Get1(i));
            }
        }
    }
}