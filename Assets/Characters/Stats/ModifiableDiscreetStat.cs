using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{

    [AdvancedInspector]
    public class ModifiableDiscreetStat : ModifiableStat
    {
        public ModifiableDiscreetStat(StatType type, float initialBaseValue) : base(type, initialBaseValue)
        {

        }

        public override float Value
        {
            get { return Mathf.Round(base.Value); }
        }

        public override float BaseValue
        {
            get { return Mathf.Round(base.BaseValue); }
            set { base.BaseValue = value; }
        }


    }
}
