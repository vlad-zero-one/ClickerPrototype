using System;
using System.Collections.Generic;

namespace Game.Save
{
    [Serializable]
    public class SaveData
    {
        public double Balance;

        public List<SaveDataBusiness> Bisunesses;
    }

    [Serializable]
    public class SaveDataBusiness
    {
        public string Id;
        public int Level;
        public float Progress;
        public bool FirstUpgradeBought;
        public bool SecondUpgradeBought;
    }
}
