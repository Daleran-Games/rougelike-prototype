using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{
    [AdvancedInspector]
    [Serializable]
    public class Stat : IDataChanged
    {

        public Stat()
        {
            StatType = StatType.None;
            BaseValue = 0f;
        }

        public Stat(StatType statType)
        {
            StatType = statType;
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

        [SerializeField]
        StatType type;
        [Inspect]
        public virtual StatType StatType
        {
            get { return type; }
            protected set { type = value; }
        }


        [SerializeField]
        float baseValue;
        [Inspect]
        public virtual float BaseValue
        {
            get { return baseValue; }
            set
            {
                if (StatChanged != null)
                    StatChanged(baseValue, value);

                baseValue = value;
                OnDataChangedHelper();
            }
        }

        [Inspect]
        public virtual float Value
        {
            get { return baseValue; }
        }

        public event GenericEventHandler OnDataChanged;
        public void DataChanged()
        {
        }

        public virtual void OnDataChangedHelper()
        {
            if (OnDataChanged != null)
                OnDataChanged();
        }
    }

}