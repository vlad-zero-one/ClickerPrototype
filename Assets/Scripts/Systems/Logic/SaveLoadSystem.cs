using Leopotam.Ecs;
using UnityEngine;
using Game.Save;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Game.Configs;
using Game.Components;
using System.Collections.Generic;

namespace Game.Systems
{
    public class SaveLoadSystem : IEcsInitSystem, IEcsDestroySystem, IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly SaveConfig saveConfig;

        private readonly BalanceManager balanceManager;

        private readonly EcsFilter<DropSaveComponent> dropSaveFilter;

        private readonly EcsFilter<BusinessComponent> businessesFilter;

        private string saveFilePath;

        public void Init()
        {
            saveFilePath = $"{Application.persistentDataPath}/{saveConfig.SaveFileName}";

            if (File.Exists(saveFilePath))
            {
                LoadGame();
            }

            Application.focusChanged += SaveGame;
            Application.quitting += SaveGame;
        }

        public void Run()
        {
            if (!dropSaveFilter.IsEmpty())
            {
                if (File.Exists(saveFilePath))
                {
                    File.Delete(saveFilePath);

                    Application.focusChanged -= SaveGame;
                    Application.quitting -= SaveGame;
                }
            }
        }

        public void Destroy()
        {
            Application.focusChanged -= SaveGame;
            Application.quitting -= SaveGame;
        }

        private void SaveGame(bool focus)
        {
            if (!focus) SaveGame();
        }

        private void SaveGame()
        {
            var formatter = new BinaryFormatter();
            var file = File.Create(saveFilePath);
            var data = new SaveData();

            data.Balance = balanceManager.Balance;
            foreach (var i in businessesFilter)
            {
                ref var businessEntuty = ref businessesFilter.GetEntity(i);
                if (businessEntuty.Has<ProgressComponent>())
                {
                    ref var business = ref businessEntuty.Get<BusinessComponent>();
                    var progress = businessEntuty.Get<ProgressComponent>().Progress;

                    data.Bisunesses.Add(new SaveDataBusiness(ref business, progress));
                }
            }

            formatter.Serialize(file, data);
            file.Close();

#if UNITY_EDITOR
            Debug.Log("Game data saved!");
#endif
        }

        private void LoadGame()
        {
            var formatter = new BinaryFormatter();
            var file = File.Open(saveFilePath, FileMode.Open);
            var data = (SaveData)formatter.Deserialize(file);
            file.Close();

            balanceManager.SetMoney(data.Balance);
            ecsWorld.NewEntity().Get<UpdateBalanceViewComponent>();

            var businessLoadData = new Dictionary<string, SaveDataBusiness>();

            foreach (var businessData in data.Bisunesses)
            {
                businessLoadData.Add(businessData.Id, businessData);
            }

            foreach (var i in businessesFilter)
            {
                ref var entity = ref businessesFilter.GetEntity(i);
                ref var businessComponent = ref businessesFilter.Get1(i);

                if (businessLoadData.TryGetValue(businessComponent.Id, out var businessData))
                {
                    businessComponent.FromLoad(businessData);

                    entity.Get<ProgressComponent>().Progress = businessData.Progress;
                    entity.Get<UpdateBusinessViewComponent>();
                }
            }

#if UNITY_EDITOR
            Debug.Log("Game data loaded!");
#endif
        }
    }
}