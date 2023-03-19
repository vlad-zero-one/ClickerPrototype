using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu]
    public class SaveConfig : ScriptableObject
    {
        [SerializeField] private string saveFileName;

        public string SaveFileName => saveFileName;
    }
}
