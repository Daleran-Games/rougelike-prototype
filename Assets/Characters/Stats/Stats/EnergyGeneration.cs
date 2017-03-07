using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class EnergyGeneration : Stat<float>
    {
        public EnergyGeneration (float amount)
        {
            StatValue = amount;
            TypeStat = GetStatType("Energy Generation");
        }
    } 
}
