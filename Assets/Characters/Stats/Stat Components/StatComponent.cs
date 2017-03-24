using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.RPGFramework;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{
    [AdvancedInspector]
    public abstract class StatComponent : MonoBehaviour
    {
        [Inspect]
        [SerializeField]
        protected StatCollection stats;

        protected virtual void Awake()
        {
            stats = gameObject.GetRequiredComponent<StatCollection>();
        }


    } 
}
