using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public abstract class RandomRangeFloatStat : DynamicStat<float> 
    {

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