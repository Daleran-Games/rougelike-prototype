using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class EnergyUse : Stat<float>
    {
        public EnergyUse(float amount)
        {
            StatValue = amount;
            TypeStat = GetStatType("Energy Use");
        }
    }

}
