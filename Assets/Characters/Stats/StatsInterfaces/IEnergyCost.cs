using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.RPGFramework
{
    public interface IEnergyCost
    {

        FloatStat EnergyCost { get; set; }
        Action<float> EnergyUsed(float amount);

    } 
}
