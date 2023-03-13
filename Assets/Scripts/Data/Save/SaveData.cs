using System;
using System.Collections.Generic;

namespace Game.Save
{
    [Serializable]
    public class SaveData
    {
        public double Balance;

        public List<SaveDataBusiness> Bisunesses = new();
    }
}
