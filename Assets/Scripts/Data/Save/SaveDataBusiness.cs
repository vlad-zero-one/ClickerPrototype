using System;

namespace Game.Save
{
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
            FirstUpgradeBought = business.FirstUpgrade.Bought;
            SecondUpgradeBought = business.SecondUpgrade.Bought;
        }
    }
}
