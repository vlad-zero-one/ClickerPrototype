using System;
using UnityEngine;

namespace Game.Configs
{
    [Serializable]
    public class BusinessNamesData
    {
        public string Id;
        [Space]
        public string BusinessName;
        public string FirstUpgradeName;
        public string SecondUpgradeName;
    }
}
