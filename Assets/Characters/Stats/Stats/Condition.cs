using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class Condition : ScaleFloatStat
    {
        public Condition (float maxValue)
        {
            StatValue = maxValue;
            StatMaxValue = maxValue;
            TypeStat = GetStatType("Condition");
        }      
    }
}