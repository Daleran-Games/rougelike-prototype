using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{

    [AdvancedInspector]
    public class Modifier
    {

        public enum Operator
        {
            Add = 0,
            Multiply = 1,
            Set = 2
        }

        public Modifier()
        {
            StatEffected = StatType.None;
            ModOperator = Operator.Add;
            Amount = 0f;
        }

        public Modifier(StatType effectedType, Operator op, float amt)
        {
            StatEffected = effectedType;
            ModOperator = op;
            Amount = amt;        
        }

        protected StatType statEffected;
        [Inspect]
        public StatType StatEffected
        {
            get { return statEffected; }
            protected set { statEffected = value; }
        }

        protected Operator modOperator;
        [Inspect]
        public Operator ModOperator
        {
            get { return modOperator; }
            protected set { modOperator = value; }
        }

        protected float amount;
        [Inspect]
        public float Amount
        {
            get { return amount; }
            protected set { amount = value; }
        }

    }
}
