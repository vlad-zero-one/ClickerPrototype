using Leopotam.Ecs;
using Game.View;

namespace Game.Systems
{
    public class CreateBusinessViewsSystem : IEcsInitSystem
    {
        private readonly BusinessViewsController businessViewsController;

        private readonly BusinessesManager businessesManager;
        
        public void Init()
        {
            foreach (var business in businessesManager.Businesses.Values)
            {
                businessViewsController.Instantiate(business);
            }
        }
    }
}