using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public class Stat
    {
        protected Stat (StatType statType)
        {
            type = statType;
        }

        public Stat(StatType statType, float initialValue)
        {
            value = initialValue;
            type = statType;
        }

        protected Action<float, float> statChanged;
        public virtual Action<float, float> StatChanged
        {
            get { return statChanged; }
            set { statChanged = value; }
        }

        [SerializeField]
        [ReadOnly]
        protected StatType type;
        public virtual StatType Type
        {
            get { return type; }
            protected set { type = value; }
        }

        [SerializeField]
        protected float value;
        public virtual float Value
        {
            get { return value; }
            set
            {
                if (StatChanged != null)
                    StatChanged(this.value, value);

                this.value = value;
            }
        }

        public virtual void ProcessModifier(Modifier modifier)
        {
            if (modifier.StatEffected == Type && modifier.Permanent == true)
            {
                if (modifier.ModifyBy == Operation.Add)
                    Value += modifier.Amount;
                else if (modifier.ModifyBy == Operation.Multiply)
                    Value *= (1 + modifier.Amount);
                else if (modifier.ModifyBy == Operation.Set)
                    Value = modifier.Amount;
            }
        }
    }

}