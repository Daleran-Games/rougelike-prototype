using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{

    [AdvancedInspector]
    [Serializable]
    public class StatCollection : MonoBehaviour, IDataChanged
    {

        [Inspect]
        [SerializeField]
        StatDictionary statDictionary = new StatDictionary();

        public StatCollection()
        {

        }

        public bool ContainsStat(StatType type)
        {
            return statDictionary.ContainsKey(type);
        }

        public Stat GetStat(StatType type)
        {
            if (ContainsStat(type))
                return statDictionary[type];

            return null;
        }

        public T GetStat<T> (StatType type) where T : Stat
        {
            return GetStat(type) as T;
        }

        public T GetOrAddStat<T>(Stat newStat) where T : Stat
        {
            T stat = GetStat<T>(newStat.StatType);
            if (stat == null)
            {
                statDictionary.Add(newStat.StatType, newStat);
                OnDataChangedHelper();
                return newStat as T;
            }
            else
                return stat;
        }

        public bool RemoveStat (StatType type)
        {

            if (statDictionary.Remove(type))
            {
                OnDataChangedHelper();
                return true;
            }
            else
                return false;
        }

        public event GenericEventHandler OnDataChanged;
        public void DataChanged()
        {

        }

        public void OnDataChangedHelper ()
        {
            if (OnDataChanged != null)
                OnDataChanged();
        }
    }
}
