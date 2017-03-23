using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{

    [AdvancedInspector]
    public class VitalDiscreetStat : VitalStat
    {


        public VitalDiscreetStat(StatType type, float initialMaxValue) : base(type, initialMaxValue)
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

        public override float BaseMaxValue
        {
            get { return Mathf.Round(base.BaseMaxValue); }
            set { base.BaseMaxValue = value; }
        }

        public override float MaxValue
        {
            get { return Mathf.Round(base.MaxValue); }
        }

    }
}
