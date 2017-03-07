using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public delegate void StatChangeHandler<T>(T newValue);

    [System.Serializable]
    public abstract class Stat<T> : IStat where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {

        public StatChangeHandler<T> StatChangedEvent;

        [SerializeField]
        protected StatType typeStat;
        public virtual StatType TypeStat { get; protected set; }

        [SerializeField]
        protected T statValue;
        public virtual T StatValue
        {
            get { return statValue; }
            set
            {
                statValue = value;

                if (StatChangedEvent !=null)
                    StatChangedEvent(value);
            }
        }


        protected virtual StatType GetStatType (string name)
        {
            foreach (StatType t in GameManager.Instance.Database.StatTypes)
            {
                if (t.StatName == name)
                {
                    return t;
                }
            }
            Debug.LogError("DG ERROR: StatType "+ name + " not in GameDatabase");
            return null;
        }

      
    } 
}
