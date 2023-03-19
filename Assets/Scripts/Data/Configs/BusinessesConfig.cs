using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu]
    public class BusinessesConfig : ScriptableObject
    {
        [SerializeField] private List<BusinessData> values;
        [SerializeField] private string initialBusinessId;

        public IReadOnlyList<BusinessData> Values => values;
        public string InitialBusinessId => initialBusinessId;
    }
}
