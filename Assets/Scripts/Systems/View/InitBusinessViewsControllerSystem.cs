using Leopotam.Ecs;
using Game.View;

namespace Game.Systems
{
    public class InitBusinessViewsControllerSystem : IEcsInitSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly BusinessViewsController businessViewsController;
        
        public void Init()
        {
            businessViewsController.Init(ecsWorld);
        }
    }
}