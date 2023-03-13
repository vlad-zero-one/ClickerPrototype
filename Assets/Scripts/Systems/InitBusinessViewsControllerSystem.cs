using Leopotam.Ecs;
using Game.View;

namespace Game.Systems
{
    public class InitBusinessViewsControllerSystem : IEcsInitSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly BusinessViewController businessViewController;
        
        public void Init()
        {
            businessViewController.Init(ecsWorld);
        }
    }
}