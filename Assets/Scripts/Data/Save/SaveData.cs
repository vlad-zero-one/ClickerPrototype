using System;
using System.Collections.Generic;

namespace Game.Save
{
    [Serializable]
    public class SaveData
    {
        public readonly List<SaveDataBusiness> Bisunesses = new();

        public double Balance;
    }
}
