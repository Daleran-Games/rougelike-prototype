using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{
    [AdvancedInspector]
    [Serializable]
    public class CounterStat : Stat
    {

        public CounterStat()
        {
            StatType = StatType.None;
            BaseValue = 0f;
        }

        public CounterStat(StatType statType)
        {
            StatType = statType;
            BaseValue = 0f;
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
                else
                    base.BaseValue = value;
            }
        }

        [Inspect]
        public virtual float Min
        {
            get { return 0f; }
        }

        protected Action statDepleted;
        public Action StatDepleted
        {
            get { return statDepleted; }
            set { statDepleted = value; }
        }

    }

}