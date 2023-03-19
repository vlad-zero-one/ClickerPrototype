using System;
using UnityEngine;

namespace Game.Configs
{
    [Serializable]
    public class BusinessUpgradeData
    {
        [SerializeField] private string id;
        [SerializeField] private double price;
        [SerializeField] private float factor;

        public string Id => id;
        public double Price => price;
        public float Factor => factor;
    }
}
