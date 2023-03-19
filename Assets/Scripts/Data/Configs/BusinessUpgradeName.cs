using System;
using UnityEngine;

namespace Game.Configs
{    
    [Serializable]
    public class BusinessUpgradeName
    {
        [SerializeField] private string id;
        [SerializeField] private string name;

        public string Id => id;
        public string Name => name;
    }
}