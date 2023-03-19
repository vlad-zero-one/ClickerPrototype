using Game.View;
using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class UpdateBalanceViewSystem : IEcsRunSystem 
    {
        private readonly BalanceView balanceView;
        private readonly BalanceManager balanceManager;

        private readonly EcsFilter<UpdateBalanceViewComponent> filter;
        
        public void Run ()
        {
            if (!filter.IsEmpty())
            {
                balanceView.SetValue(balanceManager.Balance);
            }
        }
    }
}