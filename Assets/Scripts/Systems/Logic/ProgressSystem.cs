using Game.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Systems
{
    public class ProgressSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld;

       // private readonly EcsFilter<BusinessComponent, ProgressComponent> progressFilter;

        private readonly EcsFilter<NewBusinessComponent, ProgressComponent> newProgressFilter;


        public void Run()
        {
            //foreach (var i in progressFilter)
            //{
            //    var business = progressFilter.Get1(i).Business;
            //    ref var progress = ref progressFilter.Get2(i);

            //    progress.Progress += Time.deltaTime;

            //    var delta = progress.Progress - business.IncomeTime;

            //    if (delta >= 0)
            //    {
            //        ecsWorld.NewEntity().Get<IncomeComponent>().Income = business.Income;
            //        progress.Progress = delta;
            //    }
            //}

            foreach (var i in newProgressFilter)
            {
                ref var business = ref newProgressFilter.Get1(i);
                ref var progress = ref newProgressFilter.Get2(i);

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