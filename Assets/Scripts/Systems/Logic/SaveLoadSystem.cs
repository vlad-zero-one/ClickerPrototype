using Leopotam.Ecs;
using UnityEngine;
using Game.Save;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Game.Configs;
using Game.Components;

namespace Game.Systems
{
    public class SaveLoadSystem : IEcsInitSystem, IEcsDestroySystem, IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld;

        private readonly SaveConfig saveConfig;

        private readonly BusinessesManager businessesManager;

        private readonly EcsFilter<BusinessComponent, ProgressComponent> progressFilter;

        private readonly EcsFilter<DropSaveComponent> dropSaveFilter;

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
            foreach (var i in dropSaveFilter)
            {
                dropSaveFilter.GetEntity(i).Del<DropSaveComponent>();

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
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create(saveFilePath);
            SaveData data = new SaveData();

            data.Balance = businessesManager.Balance;
            foreach(var i in progressFilter)
            {
                var business = progressFilter.Get1(i).Business;
                var progress = progressFilter.Get2(i).Progress;

                data.Bisunesses.Add(new SaveDataBusiness(business, progress));
            }

            formatter.Serialize(file, data);
            file.Close();

#if UNITY_EDITOR
            Debug.Log("Game data saved!");
#endif
        }

        private void LoadGame()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(saveFilePath, FileMode.Open);
            SaveData data = (SaveData)formatter.Deserialize(file);
            file.Close();

            businessesManager.SetMoney(data.Balance);
            ecsWorld.NewEntity().Get<UpdateBalanceComponent>();

            foreach (var businessData in data.Bisunesses)
            {
                if (businessesManager.LoadBusiness(businessData))
                {
                    var progressEntity = ecsWorld.NewEntity();
                    progressEntity.Get<BusinessComponent>().Business = businessesManager.Businesses[businessData.Id];
                    progressEntity.Get<ProgressComponent>().Progress = businessData.Progress;
                    progressEntity.Get<UpdateBusinessComponent>().Business = businessesManager.Businesses[businessData.Id];
                }
            }

#if UNITY_EDITOR
            Debug.Log("Game data loaded!");
#endif
        }
    }
}