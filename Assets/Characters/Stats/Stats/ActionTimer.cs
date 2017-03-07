using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class ActionTimer : ScaleFloatStat
    {
        public ActionTimer(float maxValue)
        {
            StatValue = maxValue;
            StatMaxValue = maxValue;
            TypeStat = GetStatType("Action Timer");
        }
    } 
}
