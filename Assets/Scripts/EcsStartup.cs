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
        [SerializeField] private BusinessViewController viewController;


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
                // .OneFrame<TestComponent2> ()

                .Inject(businessesConfig)
                .Inject(namesConfig)
                .Inject(saveConfig)
                .Inject(balanceView)
                .Inject(viewController)
                .Inject(new BusinessesManager());


            systems.Init();
        }

        private EcsSystems CreateSystems()
        {
            var systems = new EcsSystems(world);

            systems
                .Add(new CreateBusinessesSystem())
                .Add(new SaveLoadSystem())
                .Add(new LevelUpSystem());

            return systems;
        }

        private EcsSystems CreateViewSystems()
        {
            var systems = new EcsSystems(world);

            systems
                .Add(new CreateBusinessViewsSystem())
                .Add(new UpdateBalanceViewSystem())
                .Add(new UpdateBusinessViewSystem());

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