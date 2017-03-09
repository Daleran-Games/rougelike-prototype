using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public delegate void DynamicStatChangeHandler<T>(T originalValue, T newValue);

    [System.Serializable]
    public abstract class DynamicStat<T> : Stat<T> where T: struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {

        public StatChangeHandler<T> MinValueChanged;
        public StatChangeHandler<T> MaxValueChanged;
        public DynamicStatChangeHandler<T> DynamicValueChanged;

        [SerializeField]
        protected T statMinValue;
        public virtual T StatMinValue
        {
            get { return statMinValue; }
            set
            {
                if (value.CompareTo(StatMaxValue) > 0)
                {
                    statMinValue = StatMaxValue;

                    if (MinValueChanged != null)
                        MinValueChanged(StatMaxValue);
                }
                else
                {
                    statMinValue = value;

                    if (MinValueChanged != null)
                        MinValueChanged(value);
                }
            }
        }

        public override T StatValue
        {
            get { return statValue; }
            set
            {

                if (value.CompareTo(StatMinValue) < 0)
                {
                    if (DynamicValueChanged != null)
                        DynamicValueChanged(statValue, StatMinValue);

                    statValue = StatMinValue;

                    if (StatChangedEvent != null)
                        StatChangedEvent(StatMinValue);
                }

                else if (value.CompareTo(StatMaxValue) > 0)
                {
                    if (DynamicValueChanged != null)
                        DynamicValueChanged(statValue, StatMaxValue);

                    statValue = StatMaxValue;

                    if (StatChangedEvent != null)
                        StatChangedEvent(StatMaxValue);
                }
                else
                {
                    if (DynamicValueChanged != null)
                        DynamicValueChanged(statValue, value);

                    statValue = value;

                    if (StatChangedEvent != null)
                        StatChangedEvent(value);
                }
            }
        }

        [SerializeField]
        protected T statMaxValue;
        public virtual T StatMaxValue
        {
            get { return statMaxValue; }
            set
            {
                if (value.CompareTo(StatMinValue) < 0)
                {
                    statMaxValue = StatMinValue;

                    if (MaxValueChanged != null)
                        MaxValueChanged(StatMinValue);
                }
                else
                {
                    statMaxValue = value;

                    if (MaxValueChanged != null)
                        MaxValueChanged(value);
                }
            }
        }

    }

}