using System;
using System.Collections.Generic;

namespace Game.Save
{
    [Serializable]
    public class SaveData
    {
        public double Balance;

        public List<SaveDataBusiness> Bisunesses;

        public SaveData()
        {
            Bisunesses = new();
        }
    }

    [Serializable]
    public class SaveDataBusiness
    {
        public string Id;
        public int Level;
        public float Progress;
        public bool FirstUpgradeBought;
        public bool SecondUpgradeBought;

        public SaveDataBusiness(Business business, float progress)
        {
            Id = business.Id;
            Level = business.Level;
            Progress = progress;
            FirstUpgradeBought = business.firstUpgrade.Bought;
            SecondUpgradeBought = business.secondUpgrade.Bought;
        }
    }
}
