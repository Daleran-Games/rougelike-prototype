using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class FloatStatModifier : IModifier<float>
    {
        public FloatStatModifier(string desc, StatType stat, Operation op, float amt)
        {
            Description = desc;
            StatEffected = stat;
            ModifyBy = op;
            Amount = amt;
        }

        [SerializeField]
        protected string description;
        public virtual string Description
        {
            get
            {
                return description;
            }
            protected set
            {
                description = value;
            }
        }

        [SerializeField]
        protected StatType statEffected;
        public virtual StatType StatEffected
        {
            get
            {
                return statEffected;
            }
            protected set
            {
                statEffected = value;
            }
        }

        [SerializeField]
        protected Operation modifyBy;

        public virtual Operation ModifyBy
        {
            get
            {
                return modifyBy;
            }
            protected set
            {
                modifyBy = value;
            }
        }

        [SerializeField]
        protected float amount;
        public virtual float Amount
        {
            get
            {
                return amount;
            }
            protected set
            {
                amount = value;
            }
        }

    }
}
