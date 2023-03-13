using Leopotam.Ecs;
using Game.Configs;
using System.Linq;
using Game.Components;
using Game.View;
using System;

namespace Game.Systems
{
    public class CreateBusinessViewsSystem : IEcsInitSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly BusinessViewController businessViewController;

        private readonly BusinessesManager businessesManager;

        //private readonly EcsFilter<CreateBusinessViewComponent> filter;
        
        public void Init()
        {
            businessViewController.Init(ecsWorld);

            foreach(var business in businessesManager.Businesses)
            {
                businessViewController.Instantiate(business);

                //view.OnLevelUpClick += TryBuy;
            }

            //foreach(var i in filter)
            //{
            //    ref var comp = ref filter.Get1(i);

            //    businessViewController.Instantiate(comp.Business);
            //}
        }

        private void TryBuy(double price)
        {
            throw new NotImplementedException();
        }
    }
}