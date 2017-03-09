using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class RandomRangeFloatStat : DynamicStat<float> 
    {
        public RandomRangeFloatStat()
        {
            TypeStat = GameManager.Instance.Database.DefaultStatType;
            StatMinValue = 0f;
            StatMaxValue = 0f;
        }

        public RandomRangeFloatStat(float min, float max)
        {
            TypeStat = GameManager.Instance.Database.DefaultStatType;
            StatMinValue = min;
            StatMaxValue = max;
        }

        public RandomRangeFloatStat(StatType type)
        {
            TypeStat = type;
            StatMinValue = 0f;
            StatMaxValue = 0f;
        }

        public RandomRangeFloatStat(StatType type, float min, float max)
        {
            TypeStat = type;
            StatMinValue = min;
            StatMaxValue = max;
        }

        public override float StatValue
        {
            get
            {
                float randomFloat = UnityEngine.Random.Range(StatMinValue, StatMaxValue);

                if (DynamicValueChanged != null)
                    DynamicValueChanged(randomFloat, randomFloat);

                if (StatChangedEvent != null)
                    StatChangedEvent(randomFloat);

                return randomFloat;

            }
            set
            {
                //Do nothing as this only generates random numbers between the min and the max.
                Debug.Log("DG ERROR: Something is calling set on a random range stat value.");
            }
        }


    }

}