using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class FloatStatChanger : IChanger<float>
    {

        public FloatStatChanger(StatType stat, Operation op, float amt)
        {
            StatEffected = stat;
            ModifyBy = op;
            Amount = amt;
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


        public Action<IChanger<float>> changeConsumed;
        public Action<IChanger<float>> ChangeConsumed
        {
            get
            {
                return changeConsumed;
            }

            set
            {
                changeConsumed = value;
            }
        }
    }
}