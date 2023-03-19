using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Configs
{
    [Serializable]
    public class BusinessNamesData
    {
        [SerializeField] private string id;
        [Space]
        [SerializeField] private string businessName;
        [Space]
        [SerializeField] private List<IdNames> upgradeNames;

        public string Id => id;
        public string BusinessName => businessName;
        public Dictionary<string, string> UpgradeNames => upgradeNames.ToDictionary(idName => idName.Id, idName => idName.Name);
    }

    [Serializable]
    public class IdNames
    {
        public string Id;
        public string Name;
    }
}
