using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.RPGFramework;

namespace DaleranGames.Characters
{
    public class EnergyComponent : CharacterComponent
    {
        public FloatStat EnergyGeneration;
        public ScaleFloatStat Energy;

        public Color32 ChargeColor;
        public AudioClip[] ChargeSounds;

        public void Start()
        {
            EnergyGeneration = new FloatStat(GameManager.Instance.Database.EnergyGeneration ,EnergyGeneration.StatValue);
            Energy = new ScaleFloatStat(GameManager.Instance.Database.Energy, Energy.StatMaxValue);
        }

    } 
}
