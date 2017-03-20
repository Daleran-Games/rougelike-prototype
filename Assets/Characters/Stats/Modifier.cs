using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [Serializable]
    public abstract class Modifier
    {
        [SerializeField]
        protected StatType statEffected;
        public StatType StatEffected { get { return statEffected; } }

        [SerializeField]
        protected bool permanent;
        public bool Permanent { get { return permanent; } }

        [SerializeField]
        protected Operation modifyBy;
        public Operation ModifyBy { get { return modifyBy; } }

        [SerializeField]
        protected float amount;
        public float Amount { get { return amount; } }



    } 
}
