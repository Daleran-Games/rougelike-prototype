using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class PositiveModifiableFloatStat : ModifiableFloatStat
    {
        public PositiveModifiableFloatStat(StatType statType, float amount) : base(statType, amount)
        {
        }

        public virtual float Value
        {
            get
            {
                return modifiedValue;
            }

            protected set
            {
                if (StatModified != null)
                    StatModified(modifiedValue, MathExtensions.ClampPositive(value));

                modifiedValue = MathExtensions.ClampPositive(value);
            }
        }
    }
}