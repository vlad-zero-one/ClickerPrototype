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
        public readonly IReadOnlyDictionary<string, bool> IsUpgradeBought;

        public SaveDataBusiness(ref BusinessComponent business, float progress)
        {
            Id = business.Id;
            Level = business.Level;
            Progress = progress;
            var upgrades = new Dictionary<string, bool>();

            foreach (var upgrade in business.Upgrades)
            {
                upgrades.Add(upgrade.Id, upgrade.Bought);
            }

            IsUpgradeBought = upgrades;
        }
    }
}
