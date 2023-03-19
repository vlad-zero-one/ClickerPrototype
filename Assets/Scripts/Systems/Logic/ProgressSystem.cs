using Game.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Systems
{
    public class ProgressSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly EcsFilter<BusinessComponent, ProgressComponent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var business = ref filter.Get1(i);
                ref var progress = ref filter.Get2(i);

                progress.Progress += Time.deltaTime;

                var delta = progress.Progress - business.IncomeTime;

                if (delta >= 0)
                {
                    ecsWorld.NewEntity().Get<IncomeComponent>().Income = business.Income;
                    progress.Progress = delta;
                }
            }
        }
    }
}