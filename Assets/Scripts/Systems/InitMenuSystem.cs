using Leopotam.Ecs;
using Game.View;

namespace Game.Systems
{
    public class InitMenuSystem : IEcsInitSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly Menu menu;
        
        public void Init()
        {
            menu.Init(ecsWorld);
        }
    }
}