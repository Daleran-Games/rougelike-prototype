using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class ModifiableScaleFloatStat : IModifiable<float>, IMaxRangeable<float>
    {

        [SerializeField]
        protected FloatStat current;
        [SerializeField]
        protected ModifiableFloatStat max;

        public ModifiableScaleFloatStat(StatType statType, StatType maxStatType, float initialAmount, float maxAmount)
        {
            current = new FloatStat(statType, initialAmount);
            max = new ModifiableFloatStat(maxStatType, maxAmount);
        }

        public StatType Type { get { return current.Type; } }
        public StatType MaxType { get { return max.Type; } }

        public Action MinReached { get; set; }
        public Action MaxReached { get; set; }

        public Action<float,float> StatChanged
        {
            get { return current.StatChanged; }
            set { current.StatChanged = value; }
        }

        public Action<float,float> MaxStatChanged
        {
            get { return max.StatChanged; }
            set { max.StatChanged = value; }
        }

        public Action<float,float> StatModified
        {
            get { return max.StatModified; }
            set { max.StatModified = value; }
        }

        public float BaseValue
        {
            get { return max.BaseValue; }
            set
            {
                if (value < Min)
                    max.BaseValue = Min;
                else
                    max.BaseValue = value;
            }
        }

        public float Min
        {
            get { return 0; }
        }

        public float Max
        {
            get { return max.Value; }
        }

        public float Value
        {
            get { return current.Value; }
            set
            {
                if (value < Min)
                {
                    current.Value = Min;

                    if (MinReached != null)
                        MinReached();
                }
                else if (value > Max)
                {
                    current.Value = Max;

                    if (MaxReached != null)
                        MaxReached();
                }
                else
                    current.Value = value;
            }
        }

        public virtual void OnModifierAdded(IModifier<float> modifier)
        {
            FloatStatModifier floatMod = modifier as FloatStatModifier;

            if (floatMod != null && modifier.StatEffected == MaxType)
            {
                max.OnModifierAdded(floatMod);
            }

        }

        public virtual void OnModifierRemoved(IModifier<float> modifier)
        {
            FloatStatModifier floatMod = modifier as FloatStatModifier;
            if (floatMod != null && modifier.StatEffected == MaxType)
            {
                max.OnModifierRemoved(floatMod);
            }
        }

        public virtual void OnChangeRecieved(IChanger<float> change)
        {
            FloatStatChanger floatChanger = change as FloatStatChanger;

            if (floatChanger != null)
            {
                if (floatChanger.StatEffected == Type)
                    current.OnChangeRecieved(floatChanger);
                else if (floatChanger.StatEffected == MaxType)
                    max.OnChangeRecieved(floatChanger);
            }
        }

    }
}