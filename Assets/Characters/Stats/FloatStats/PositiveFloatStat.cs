using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class PositiveFloatStat : FloatStat
    {
        public PositiveFloatStat(StatType statType, float amount) : base(statType, amount)
        {
        }

        public override float Value
        {
            get { return value; }
            set
            {
                if (StatChanged != null)
                    StatChanged(this.value, MathExtensions.ClampPositive(value));

                this.value = MathExtensions.ClampPositive(value);

            }
        }
    }
}
