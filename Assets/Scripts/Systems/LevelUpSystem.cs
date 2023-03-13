using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class LevelUpSystem : IEcsRunSystem
    {
        private readonly BusinessesManager businessesManager;

        private readonly EcsFilter<LevelUpClickComponent> filter;
        
        public void Run ()
        {
            foreach(var i in filter)
            {
                var business = filter.Get1(i).Business;
                ref var entity = ref filter.GetEntity(i);

                if (businessesManager.LevelUp(business))
                {
                    ref var comp = ref entity.Get<UpdateBusinessComponent>();
                    comp.Business = business;

                    entity.Get<UpdateBalanceComponent>();
                }

                entity.Del<LevelUpClickComponent>();
            }
        }
    }
}