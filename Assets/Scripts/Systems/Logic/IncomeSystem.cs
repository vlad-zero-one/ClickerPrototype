using Game.Components;
using Leopotam.Ecs;

namespace Game.Systems
{
    public class IncomeSystem : IEcsRunSystem 
    {
        readonly private EcsFilter<IncomeComponent> filter;

        readonly private BalanceManager balanceManager;

        public void Run()
        {
            foreach(var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);
                balanceManager.AddMoney(filter.Get1(i).Income);

                entity.Get<UpdateBalanceComponent>();
                entity.Del<IncomeComponent>();
            }
        }
    }
}