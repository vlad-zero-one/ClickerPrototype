using Leopotam.Ecs;
using Game.Configs;
using Game.Components;

namespace Game.Systems
{
    public class InitialBusinessSystem : IEcsInitSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly BusinessesConfig businessesConfig;

        private readonly BusinessesManager businessesManager;

        private readonly EcsFilter<BusinessComponent, ProgressComponent> progressFilter;

        private readonly EcsFilter<NewBusinessComponent/*, ProgressComponent*/> newProgressFilter;


        public void Init()
        {
            //var progressInited = false;

            //foreach(var i in progressFilter)
            //{
            //    var id = progressFilter.Get1(i).Business.Id;

            //    if (id == businessesConfig.InitialBusinessId)
            //    {
            //        progressInited = true;
            //        break;
            //    }
            //}

            //if (!progressInited)
            //{
            //    var business = businessesManager.Businesses[businessesConfig.InitialBusinessId];
            //    business.LevelUp();

            //    var entity = ecsWorld.NewEntity();
            //    entity.Get<BusinessComponent>().Business = business;
            //    entity.Get<ProgressComponent>();
            //}

            foreach (var i in newProgressFilter)
            {
                ref var business = ref newProgressFilter.Get1(i);

                if (business.Id != businessesConfig.InitialBusinessId)
                {
                    continue;
                }

                business.LevelUp();

                newProgressFilter.GetEntity(i).Get<ProgressComponent>();
            }
        }
    }
}