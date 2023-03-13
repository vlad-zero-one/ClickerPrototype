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

        private readonly BusinessesManager businessesManager;

        private string saveFilePath;

        public void Init()
        {
            saveFilePath = $"{Application.persistentDataPath}/{saveConfig.SaveFileName}";

            Application.quitting += SaveGame;
        }

        public void Destroy()
        {
            Application.quitting -= SaveGame;
        }

        void SaveGame()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(saveFilePath);
            SaveData data = new SaveData();

            data.Balance = businessesManager.Balance;

            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Game data saved!");
        }

        void LoadGame()
        {
            if (File.Exists(saveFilePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(saveFilePath, FileMode.Open);
                SaveData data = (SaveData)bf.Deserialize(file);
                file.Close();

                businessesManager.SetMoney(data.Balance);

                Debug.Log("Game data loaded!");
            }
            else
            {
                Debug.LogError("There is no save data!");
            }
        }

        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadGame();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                SaveGame();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                businessesManager.AddMoney(10);
                var ent = ecsWorld.NewEntity();
                ent.Get<UpdateBalanceComponent>();
            }
        }
    }
}