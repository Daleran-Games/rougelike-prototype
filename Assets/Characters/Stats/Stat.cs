using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public delegate void StatChangeHandler<T>(T newValue);

    [System.Serializable]
    public abstract class Stat<T> : IStat where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {

        public StatChangeHandler<T> StatChangedEvent;

        [SerializeField]
        [ReadOnly]
        private StatType typeStat;
        public StatType TypeStat
        {
            get { return typeStat; }
            protected set { typeStat = value; }

        }

        [SerializeField]
        protected T statValue;
        public virtual T StatValue
        {
            get { return statValue; }
            set
            {
                statValue = value;

                if (StatChangedEvent != null)
                    StatChangedEvent(value);
            }
        }

    }
}
