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
        public Stat TestcStat = new Stat(StatType.ActionTime, 18.99f);
        [Inspect]
        public DiscreetStat TestDiscreetStat = new DiscreetStat(StatType.Damage, 32.7f);
        [Inspect]
        public ModifiableStat TestModStat = new ModifiableStat(StatType.MoveSpeed, 5.65f);
        [Inspect]
        public ModifiableDiscreetStat TestModDiscreetStat = new ModifiableDiscreetStat(StatType.Armor, 5.69f);
        [Inspect]
        public VitalStat TestVitalStat = new VitalStat(StatType.Experience, 100.27f);
        [Inspect]
        public VitalDiscreetStat TestVitalDiscStat = new VitalDiscreetStat(StatType.Life, 50.37f);


        [Inspect]
        public float counter = 0f;

        // Use this for initialization
        void Start()
        {
            TestVitalStat.BaseValue = 5f;
            TestVitalDiscStat.BaseValue = 1f;
        }

        // Update is called once per frame
        void Update()
        {
            TestVitalStat.BaseValue += 5f * Time.deltaTime;
            TestVitalDiscStat.BaseValue -= 2.5f * Time.deltaTime;
            counter += 1f * Time.deltaTime;
        }
    }
}
