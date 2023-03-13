using Game.View;
using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class UpdateBalanceViewSystem : IEcsRunSystem 
    {
        private readonly BalanceView balanceView;
        private readonly BusinessesManager businessesManager;

        private readonly EcsFilter<UpdateBalanceComponent> filter;
        
        public void Run ()
        {
            if (filter.GetEntitiesCount() > 0)
            {
                balanceView.SetValue(businessesManager.Balance);
            }
        }
    }
}