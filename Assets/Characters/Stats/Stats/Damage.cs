using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.ElectricDreams
{

    public class Damage : RandomRangeFloatStat
    {
        public Damage (float min, float max)
        {
            StatMinValue = min;
            StatMaxValue = max;
            TypeStat = GetStatType("Damage");
        }
    } 
}
