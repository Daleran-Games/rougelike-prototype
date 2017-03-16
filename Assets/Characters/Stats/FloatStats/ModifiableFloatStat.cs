using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class ModifiableFloatStat : IStat<float>, IModifiable<float>
    {

        public ModifiableFloatStat(StatType statType, float amount)
        {
            baseStat = new FloatStat(statType, amount);
            RecalculateModifiedValue();
        }

        [HideInInspector]
        public static readonly ModifiableFloatStat zero = new ModifiableFloatStat(StatType.DefaultStatType, 0f);

        public virtual StatType Type
        {
            get { return baseStat.Type; }
        }

        [ReadOnly]
        [SerializeField]
        protected float modifiedValue;
        public virtual float Value
        {
            get
            {
                return modifiedValue;
            }

            protected set
            {
                if (StatModified != null)
                    StatModified(modifiedValue, value);

                modifiedValue = value;
            }
        }

        [SerializeField]
        protected FloatStat baseStat;
        public virtual float BaseValue
        {
            get
            {
                return baseStat.Value;
            }
            set
            {
                baseStat.Value = value;
                RecalculateModifiedValue();
            }
        }

        protected Action<float, float> statModified;
        public virtual Action<float, float> StatModified
        {
            get { return statModified; }
            set{ statModified = value; }
        }

        public virtual Action<float, float> StatChanged
        {
            get { return baseStat.StatChanged; }
            set { baseStat.StatChanged = value; }
        }

        [SerializeField]
        [ReadOnly]
        protected List<FloatStatModifier> modifiers = new List<FloatStatModifier>();
        public virtual void OnModifierAdded(IModifier<float> modifier)
        {
            FloatStatModifier floatMod = modifier as FloatStatModifier;

            if (floatMod != null && modifier.StatEffected == Type)
            {
                modifiers.Add(floatMod);
                RecalculateModifiedValue();
            }

        }

        public virtual void OnModifierRemoved(IModifier<float> modifier)
        {
            FloatStatModifier floatMod = modifier as FloatStatModifier;
            if (floatMod != null && modifier.StatEffected == Type)
            {
                modifiers.Remove(floatMod);
                RecalculateModifiedValue();

            }
        }

        public virtual void OnChangeRecieved(IChanger<float> change)
        {
            baseStat.OnChangeRecieved(change);
            RecalculateModifiedValue();
        }

        private void RecalculateModifiedValue ()
        {
            if (modifiers.Count > 0)
            {

                float bonusToAdd = 0f;
                float finalMultiplier = 0f;

                foreach (FloatStatModifier fsm in modifiers)
                {
                    if (fsm.ModifyBy == Operation.Add)
                        bonusToAdd += fsm.Amount;
                    else if (fsm.ModifyBy == Operation.Multiply)
                        finalMultiplier += fsm.Amount;
                    else if (fsm.ModifyBy == Operation.Set)
                    {
                        Value = fsm.Amount;
                        return;
                    }
                }
                Value = (BaseValue + bonusToAdd) * (1 + finalMultiplier);
            }
            else
            {
                Value = BaseValue;
            }
                
        }
    }
}
