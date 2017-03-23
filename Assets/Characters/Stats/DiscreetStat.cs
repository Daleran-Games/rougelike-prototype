using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{

    [AdvancedInspector]
    public class DiscreetStat : Stat
    {
        public DiscreetStat(StatType type, float initialValue) : base(type, initialValue)
        {

        }

        public override float BaseValue
        {
            get { return Mathf.Round(base.BaseValue); }
            set { base.BaseValue = value; }
        }

        public override float Value
        {
            get { return Mathf.Round(base.Value); }
        }


    }
}