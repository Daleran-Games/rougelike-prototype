using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class Range : Stat<float>
    {
        public Range(float amount)
        {
            StatValue = amount;
            TypeStat = GetStatType("Range");
        }
    }

}