using Game.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Systems
{
    public class ProgressSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly EcsFilter<BusinessComponent, ProgressComponent> progressFilter;

        public void Run()
        {
            foreach (var i in progressFilter)
            {
                var business = progressFilter.Get1(i).Business;
                ref var progress = ref progressFilter.Get2(i);

                progress.Progress += Time.deltaTime;

                if (progress.Progress >= business.IncomeTime)
                {
                    var entity = ecsWorld.NewEntity();
                    entity.Get<IncomeComponent>().Income = business.Income;
                    progress.Progress = 0;
                }
            }
        }
    }
}