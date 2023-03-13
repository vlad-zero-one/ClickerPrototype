using Leopotam.Ecs;
using Game.Configs;
using System.Linq;
using Game.Components;

namespace Game.Systems
{
    public class CreateBusinessesSystem : IEcsInitSystem
    {
        private readonly BusinessesConfig businessesConfig;
        private readonly NamesConfig namesConfig;

        private readonly BusinessesManager businessesManager;

        public void Init()
        {
            foreach(var businessData in businessesConfig.Values)
            {
                var nameData = namesConfig.Values.FirstOrDefault(data => data.Id == businessData.Id);
                nameData ??= namesConfig.Values.First();

                var business = new Business(businessData, nameData);

                if (businessesConfig.InitialBusinessId == businessData.Id)
                {
                    business.LevelUp();
                }

                businessesManager.AddBusiness(business);
            }
        }
    }
}