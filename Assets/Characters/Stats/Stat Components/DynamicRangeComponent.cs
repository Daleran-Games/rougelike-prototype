using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public abstract class DynamicRangeComponent : StatComponent
    {
        public ModifiableFloatStat Rate;
        public ModifiableScaleFloatStat Scale;

        protected virtual void Update()
        {
            if (Rate.Value != 0f)
                Scale.Value += Rate.Value * Time.deltaTime;
        }

    } 
}
