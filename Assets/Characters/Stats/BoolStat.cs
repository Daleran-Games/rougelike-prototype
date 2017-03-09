using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [System.Serializable]
    public class BoolStat : Stat<bool>
    {
        public BoolStat()
        {
            TypeStat = GameManager.Instance.Database.DefaultStatType;
            StatValue = false;
        }

        public BoolStat(StatType type)
        {
            TypeStat = type;
            StatValue = false;
        }

        public BoolStat(bool amount)
        {
            TypeStat = GameManager.Instance.Database.DefaultStatType;
            StatValue = amount;
        }

        public BoolStat(StatType type, bool amount)
        {
            TypeStat = type;
            StatValue = amount;
        }
    } 
}
