using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public class ModifiableStat : Stat
    {
        [SerializeField]
        protected float adder = 0f;
        [SerializeField]
        protected float multiplier = 0f;
        [SerializeField]
        protected float modifiedOverride = 0f;

        public ModifiableStat (StatType modifiableStatType, float baseValue) : base(modifiableStatType)
        {
            value = baseValue;
        }

        public override float Value
        {
            get
            {
                if (modifiedOverride != 0)
                    return BaseValue + adder * (1 + multiplier);
                else
                    return modifiedOverride;
            }

            set
            {
                if (StatModified != null)
                    StatModified(Value, value);

                modifiedOverride = value;
            }
        }

        public virtual float BaseValue
        {
            get
            {
                return base.Value;
            }
            set
            {
                base.Value = value;
            }
        }

        protected Action<float, float> statModified;
        public virtual Action<float, float> StatModified
        {
            get { return statModified; }
            set { statModified = value; }
        }

        public override void ProcessModifier(Modifier modifier)
        {
            base.ProcessModifier(modifier);

            if (modifier.StatEffected == Type && modifier.Permanent == false)
            {
                float originalModifier = this.Value;

                if (modifier.ModifyBy == Operation.Add)
                    adder += modifier.Amount;
                else if (modifier.ModifyBy == Operation.Multiply)
                    multiplier += (modifier.Amount);
                else if (modifier.ModifyBy == Operation.Set)
                    modifiedOverride = modifier.Amount;

                if (StatModified != null)
                    StatModified(originalModifier, Value);
            }
        }

        public virtual void UndoModifier(Modifier modifier)
        {
            if (modifier.StatEffected == Type && modifier.Permanent == false)
            {
                float originalModifier = this.Value;

                if (modifier.ModifyBy == Operation.Add)
                    adder -= modifier.Amount;
                else if (modifier.ModifyBy == Operation.Multiply)
                    multiplier -= (modifier.Amount);
                else if (modifier.ModifyBy == Operation.Set)
                    modifiedOverride = 0f;

                if (StatModified != null)
                    StatModified(originalModifier, Value);
            }
        }

    }

}
