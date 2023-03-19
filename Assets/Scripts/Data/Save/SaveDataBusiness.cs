using Game.Components;
using System;
using System.Collections.Generic;

namespace Game.Save
{
    [Serializable]
    public class SaveDataBusiness
    {
        public readonly string Id;
        public readonly int Level;
        public readonly float Progress;
        public readonly Dictionary<string, bool> IsUpgradeBought;

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
