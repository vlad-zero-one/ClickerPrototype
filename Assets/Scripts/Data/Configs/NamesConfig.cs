using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu]
    public class NamesConfig : ScriptableObject
    {
        [SerializeField] private List<BusinessNamesData> values;

        public IReadOnlyList<BusinessNamesData> Values => values;
    }
}
