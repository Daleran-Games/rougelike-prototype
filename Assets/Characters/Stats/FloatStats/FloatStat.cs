using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class FloatStat : IStat<float>
    {
        public FloatStat(StatType statType, float amount)
        {
            Type = statType;
            Value = amount;
        }

        [HideInInspector]
        public static readonly FloatStat zero = new FloatStat(StatType.DefaultStatType, 0f);

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
            get{ return type; }
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

        public virtual void OnChangeRecieved(IChanger<float> change)
        {
            FloatStatChanger floatChanger = change as FloatStatChanger;

            if (floatChanger != null && change.StatEffected == Type)
            {
                if (floatChanger.ModifyBy == Operation.Add)
                    Value += floatChanger.Amount;
                else if (floatChanger.ModifyBy == Operation.Multiply)
                    Value *= (1 + floatChanger.Amount);
                else if (floatChanger.ModifyBy == Operation.Set)
                    Value = floatChanger.Amount;

                change.ChangeConsumed(change);
            }
        }

    }
}
