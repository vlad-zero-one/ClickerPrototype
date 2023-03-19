using Leopotam.Ecs;
using Game.View;
using Game.Components;

namespace Game.Systems
{
    public class CreateBusinessViewsSystem : IEcsInitSystem
    {
        private readonly BusinessViewsController businessViewsController;

        private readonly EcsFilter<BusinessComponent> businessesFilter;

        public void Init()
        {
            foreach (var i in businessesFilter)
            {
                businessViewsController.Instantiate(ref businessesFilter.Get1(i));
            }
        }
    }
}