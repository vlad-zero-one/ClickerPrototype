using Leopotam.Ecs;
using UnityEngine;
using Game.Configs;
using Game.View;
using Game.Systems;
using Game.Components;

namespace Game
{
    public sealed class EcsStartup : MonoBehaviour
    {
        [Header("Configs")]
        [SerializeField] private BusinessesConfig businessesConfig;
        [SerializeField] private NamesConfig namesConfig;
        [SerializeField] private SaveConfig saveConfig;
        [Header("Scene Objects")]
        [SerializeField] private BalanceView balanceView;
        [SerializeField] private BusinessViewsController viewsController;
        [SerializeField] private Menu menu;

        private EcsWorld world;
        private EcsSystems systems;

        private void Start()
        {
            
            world = new EcsWorld();
            systems = new EcsSystems(world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(systems);
#endif

            systems
                .Add(CreateSystems())
                .Add(CreateViewSystems())

                .OneFrame<UpdateBalanceComponent>()

                .Inject(businessesConfig)
                .Inject(namesConfig)
                .Inject(saveConfig)
                .Inject(balanceView)
                .Inject(viewsController)
                .Inject(menu)
                //.Inject(new BusinessesManager())
                .Inject(new BalanceManager());


            systems.Init();
        }

        private EcsSystems CreateSystems()
        {
            var systems = new EcsSystems(world);

            systems
                .Add(new CreateBusinessesSystem())
                .Add(new InitialBusinessSystem())
                .Add(new SaveLoadSystem())
                .Add(new LevelUpSystem())
                .Add(new BuyUpgradeSystem())
                .Add(new ProgressSystem())
                .Add(new IncomeSystem());

            return systems;
        }

        private EcsSystems CreateViewSystems()
        {
            var systems = new EcsSystems(world);

            systems
                .Add(new InitBusinessViewsControllerSystem())
                .Add(new InitMenuSystem())
                .Add(new CreateBusinessViewsSystem())
                .Add(new UpdateBalanceViewSystem())
                .Add(new UpdateBusinessViewSystem())
                .Add(new UpdateProgressViewsSystem());

            return systems;
        }

        private void Update()
        {
            systems?.Run ();
        }

        private void OnDestroy()
        {
            if (systems != null)
            {
                systems.Destroy();
                systems = null;
                world.Destroy();
                world = null;
            }
        }
    }
}
