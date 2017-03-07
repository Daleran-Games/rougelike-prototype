using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.ElectricDreams
{
    public class Armor : RandomRangeFloatStat
    {
        public Armor(float min, float max)
        {
            StatMinValue = min;
            StatMaxValue = max;
            TypeStat = GetStatType("Armor");
        }
    } 
}
