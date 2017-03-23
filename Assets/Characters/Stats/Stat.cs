using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{
    [AdvancedInspector]
    public class Stat
    {

        public Stat()
        {
            type = StatType.None;
            BaseValue = 0f;
        }

        public Stat(StatType statType)
        {
            type = statType;
            BaseValue = 0f;
        }

        public Stat(StatType statType, float initialValue)
        {
            BaseValue = initialValue;
            StatType = statType;
        }

        protected Action<float, float> statChanged;
        public virtual Action<float, float> StatChanged
        {
            get { return statChanged; }
            set { statChanged = value; }
        }

        protected StatType type;
        [Inspect]
        public virtual StatType StatType
        {
            get { return type; }
            protected set { type = value; }
        }


        [Inspect]
        float trueValue;
        [Inspect]
        public virtual float BaseValue
        {
            get { return trueValue; }
            set
            {
                if (StatChanged != null)
                    StatChanged(trueValue, value);

                trueValue = value;
            }
        }

        [Inspect]
        public virtual float Value
        {
            get { return trueValue; }
        }

    }

}