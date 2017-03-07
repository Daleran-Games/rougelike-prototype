using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.ElectricDreams
{
    public delegate void ScaleStatHandler();

    public abstract class ScaleFloatStat : DynamicStat<float>
    {

        public ScaleStatHandler ScaleStatDepleted;

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
                if (value < 0 && ScaleStatDepleted != null)
                    ScaleStatDepleted();

                base.StatValue = value;
            }
        }



    } 
}

   

