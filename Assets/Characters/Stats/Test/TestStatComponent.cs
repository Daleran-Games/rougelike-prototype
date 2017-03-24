using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{
    [AdvancedInspector]
    public class TestStatComponent : MonoBehaviour
    {

        [Inspect]
        StatCollection statCol;

        private void Awake()
        {
        }

        // Use this for initialization
        void Start()
        {
            statCol.GetOrAddStat<VitalStat>(new VitalStat(StatType.Life, 100f, 100f));
            statCol.GetOrAddStat<VitalStat>(new VitalStat(StatType.Will, 100f, 100f));
            statCol.GetOrAddStat<ModifiableStat>(new ModifiableStat(StatType.WillRate, 1f));
            statCol.GetOrAddStat<ModifiableStat>(new ModifiableStat(StatType.Damage, 8f));
            statCol.GetOrAddStat<ModifiableStat>(new ModifiableStat(StatType.MoveSpeed, 5f));
            statCol.GetOrAddStat<VitalStat>(new VitalStat(StatType.Experience, 1000f, 0f));
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
