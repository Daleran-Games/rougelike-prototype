using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.RPGFramework
{
    [Serializable]
    public class ScaleFloatStat : DynamicStat<float>
    {

        public Action ScaleStatDepleted;

        public ScaleFloatStat()
        {
            TypeStat = GameManager.Instance.Database.DefaultStatType;
            StatValue = 0f;
            StatMaxValue = 0f;
        }

        public ScaleFloatStat(float max)
        {
            TypeStat = GameManager.Instance.Database.DefaultStatType;
            StatValue = max;
            StatMaxValue = max;
        }
        public ScaleFloatStat(StatType type)
        {
            TypeStat = type;
            StatValue = 0f;
            StatMaxValue = 0f;
        }

        public ScaleFloatStat(StatType type, float max)
        {
            TypeStat = type;
            StatValue = max;
            StatMaxValue = max;
        }

        public override float StatMinValue
        {
            get
            {
                return 0;
            }

            set
            {
                statMinValue = 0;
                Debug.LogError("DG ERROR: Something is attempting to set a Scale float stat min value.");
            }
        }

        public override float StatValue
        {
            get
            {
                return base.StatValue;
            }

            set
            {
                if (value <= 0 && ScaleStatDepleted != null)
                    ScaleStatDepleted();

                base.StatValue = value;
            }
        }



    } 
}

   

