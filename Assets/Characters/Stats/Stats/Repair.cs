using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class Repair : RandomRangeFloatStat
    {
        public Repair(float min, float max)
        {
            StatMinValue = min;
            StatMaxValue = max;
            TypeStat = GetStatType("Repair");
        }
    } 
}
