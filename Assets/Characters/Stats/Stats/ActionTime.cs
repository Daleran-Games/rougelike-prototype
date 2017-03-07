using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class ActionTime : Stat<float>
    {
        public ActionTime(float amount)
        {
            StatValue = amount;
            TypeStat = GetStatType("Action Time");
        }
    }
    
}