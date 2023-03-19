using Game.Components;
using System;
using System.Collections.Generic;

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

        public Dictionary<string, bool> IsUpgradeBought;

        public SaveDataBusiness(ref BusinessComponent business, float progress)
        {
            Id = business.Id;
            Level = business.Level;
            Progress = progress;
            IsUpgradeBought = new();

            foreach (var upgrade in business.Upgrades)
            {
                IsUpgradeBought.Add(upgrade.Id, upgrade.Bought);
            }
        }
    }
}
