using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class EnergyCost : Stat<float>
    {

        public EnergyCost (float amount)
        {
            StatValue = amount;
        }
    } 
}
