using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{
    [AdvancedInspector]
    [Expandable(Expanded = true)]
    public class ModifiableStat : Stat, IModifiable
    {

        [Inspect]
        List<Modifier> modifiers = new List<Modifier>();

        public ModifiableStat() : base()
        {
            ModifiedValue = GetNewModifiedValue();
        }

        public ModifiableStat (StatType type, float initialBaseValue) : base(type)
        {
            BaseValue = initialBaseValue;
            ModifiedValue = GetNewModifiedValue();
        }

        float modifiedValue;
        float ModifiedValue
        {
            get { return modifiedValue; }
            set
            {
                if (StatModified != null)
                    StatModified(modifiedValue, value);

                modifiedValue = value;
                OnDataChangedHelper();
            }
        }

        public override float Value
        {
            get { return ModifiedValue; }
        }

        public override float BaseValue
        {
            get { return base.BaseValue; }
            set { base.BaseValue = value; }
        }

        protected Action<float, float> statModified;
        public virtual Action<float, float> StatModified
        {
            get { return statModified; }
            set { statModified = value; }
        }

        public virtual void AddModifier(Modifier mod)
        {
            if (mod.StatEffected == StatType)
            {
                modifiers.Add(mod);
                ModifiedValue = GetNewModifiedValue();
            }
        }

        public virtual void RemoveModifier(Modifier mod)
        {
            if (mod.StatEffected == StatType)
            {
                modifiers.Remove(mod);
                ModifiedValue = GetNewModifiedValue();
            }
        }

        public virtual void ClearModifiers()
        {
            modifiers.Clear();
            ModifiedValue = GetNewModifiedValue();
        }

        protected virtual float GetNewModifiedValue ()
        {
            float result = 0f;

            if (modifiers.Count > 0)
            {

                float bonusToAdd = 0f;
                float finalMultiplier = 0f;

                for (int i = 0; i < modifiers.Count; i++)
                {
                        if (modifiers[i].ModOperator == Modifier.Operator.Add)
                        {
                            bonusToAdd += modifiers[i].Amount;
                        }
                        else if (modifiers[i].ModOperator == Modifier.Operator.Multiply)
                        {
                            finalMultiplier += modifiers[i].Amount;
                        }
                        else if (modifiers[i].ModOperator == Modifier.Operator.Set)
                        {
                            return modifiers[i].Amount;                     
                        }                 
                }
                result = (BaseValue + bonusToAdd) * (1 + finalMultiplier);
            }
            else
                result = BaseValue;

            return result;
        }

    }
}
