using Leopotam.Ecs;
using Game.Configs;
using System.Linq;
using Game.Components;

namespace Game.Systems
{
    public class CreateBusinessesSystem : IEcsInitSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly BusinessesConfig businessesConfig;
        private readonly NamesConfig namesConfig;

        public void Init()
        {
            foreach(var businessData in businessesConfig.Values)
            {
                var nameData = namesConfig.Values.FirstOrDefault(data => data.Id == businessData.Id);
                nameData ??= namesConfig.Values.First();

                var businessComponent = new BusinessComponent(businessData, nameData);
                ecsWorld.NewEntity().Replace(in businessComponent);
            }
        }
    }
}