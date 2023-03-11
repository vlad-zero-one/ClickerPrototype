using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu]
    public class BusinessesConfig : ScriptableObject
    {
        public List<BusinessData> Values;

        public string InitialBusinessId;
    }
}
