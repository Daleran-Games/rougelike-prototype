using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.RPGFramework
{
    [System.Serializable]
    public class FloatStat : Stat<float>
    {
        public FloatStat()
        {
            TypeStat = GameManager.Instance.Database.DefaultStatType;
            StatValue = 0f;
        }

        public FloatStat(float amount)
        {
            TypeStat = GameManager.Instance.Database.DefaultStatType;
            StatValue = amount;
        }

        public FloatStat(StatType type)
        {
            TypeStat = type;
            StatValue = 0f;
        }

        public FloatStat (StatType type, float amount)
        {
            TypeStat = type;
            StatValue = amount;
        }
    } 
}
