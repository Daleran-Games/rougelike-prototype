using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class Energy : ScaleFloatStat
    {
        public Energy(float maxValue)
        {
            StatValue = maxValue;
            StatMaxValue = maxValue;
            TypeStat = GetStatType("Energy");
        }
    }

}