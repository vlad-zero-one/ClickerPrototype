using Leopotam.Ecs;
using UnityEngine;
using Game.Save;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Game.Configs;

namespace Game.Systems
{
    public class SaveLoadSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly SaveConfig saveConfig;

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

                Debug.Log("Game data loaded!");
            }
            else
            {
                Debug.LogError("There is no save data!");
            }
        }
    }
}