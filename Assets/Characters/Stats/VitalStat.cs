using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{

    [AdvancedInspector]
    [Serializable]
    public class VitalStat : Stat, IModifiable
    {

        [Inspect]
        [SerializeField]
        ModifiableStat maxStat = new ModifiableStat();

        bool minOverrideEnabled = false;
        Modifier minModifier;

        public VitalStat(StatType type, float initialMaxValue, float initialValue) : base(type)
        {
            minModifier = new Modifier(StatType, Modifier.Operator.Set, Min);
            maxStat = new ModifiableStat(type, initialMaxValue);
            BaseValue = initialValue;
        }

        public override float Value
        {
            get { return base.Value; }
        }

        public override float BaseValue
        {
            get { return base.BaseValue; }
            set
            {
                if (value < Min)
                {
                    base.BaseValue = Min;
                    StatDepleted();
                }

                else if (value > MaxValue)
                {
                    base.BaseValue = MaxValue;
                    StatReplenished();
                }
                else
                    base.BaseValue = value;
            }
        }

        public virtual float BaseMaxValue
        {
            get { return maxStat.BaseValue; }
            set
            {
                if (value < Min)
                    maxStat.BaseValue = Min;
                else
                    maxStat.BaseValue = value;
            }
        }

        public virtual float MaxValue
        {
            get { return maxStat.Value; }
        }

        public Action<float, float> MaxStatChanged
        {
            get { return maxStat.StatChanged;  }
            set { maxStat.StatChanged = value; }
        }

        [Inspect]
        public virtual float Min
        {
            get { return 0f; }
        }

        public virtual Action<float, float> StatModified
        {
            get { return maxStat.StatModified; }
            set { maxStat.StatModified = value; }
        }

        protected Action statDepleted;
        public Action StatDepleted
        {
            get { return statDepleted; }
            set { statDepleted = value; }
        }

        protected Action statReplenished;
        public Action StatReplenished
        {
            get { return statReplenished; }
            set { statReplenished = value; }
        }


        public virtual void AddModifier(Modifier mod)
        {
            if (minOverrideEnabled == true)
            {
                minOverrideEnabled = false;
                maxStat.RemoveModifier(minModifier);
            }

            maxStat.AddModifier(mod);

            if (maxStat.Value < Min)
            {
                minOverrideEnabled = true;
                maxStat.AddModifier(minModifier);
            }
        }

        public virtual void RemoveModifier(Modifier mod)
        {
            if (minOverrideEnabled == true)
            {
                minOverrideEnabled = false;
                maxStat.RemoveModifier(minModifier);
            }

            maxStat.AddModifier(mod);

            if (maxStat.Value < Min)
            {
                minOverrideEnabled = true;
                maxStat.AddModifier(minModifier);
            }
        }

        public virtual void ClearModifiers()
        {
            maxStat.ClearModifiers();
        }

    }
}
