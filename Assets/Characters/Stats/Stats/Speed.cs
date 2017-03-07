using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.ElectricDreams
{

    public class Speed : Stat<float>
    {

        public Speed (float amount)
        {
            StatValue = amount;
            TypeStat = GetStatType("Speed");
        }
    } 
}
