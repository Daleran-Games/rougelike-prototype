using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.RPGFramework;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{
    [AdvancedInspector]
    public class LifeComponent : StatComponent
    {
        [Title(FontStyle.Bold,"Life Stats")]
        [Inspect]
        [SerializeField]
        VitalStat healthStat = new VitalStat(StatType.Life, 8f, 8f);

        [Title(FontStyle.Bold, "Life Config Variables")]
        [Inspect]
        [SerializeField]
        float hitTime = 1f;
        [Inspect]
        [SerializeField]
        float hitVelocity = 6f;

        [Title(FontStyle.Bold, "Life Effects")]
        [Inspect]
        [SerializeField]
        Color32 chargeColor;
        [Inspect]
        [SerializeField]
        AudioClip[] chargeSounds;
        [Inspect]
        [SerializeField]
        Color32 hitColor;
        [Inspect]
        [SerializeField]
        AudioClip[] hitSounds;

        [Title(FontStyle.Bold, "Optional Life Dependencies")]
        [Inspect]
        [SerializeField]
        MoveComponent moveComp;
        [Inspect]
        [SerializeField]
        AbilityComponent abilityComp;

        protected override void Awake()
        {
            base.Awake();

            moveComp = GetComponent<MoveComponent>();
            abilityComp = GetComponent<AbilityComponent>();

            healthStat = stats.GetOrAddStat<VitalStat>(healthStat);

            healthStat.StatDepleted += OnHealthDepleted;
            healthStat.StatChanged += OnHealthChanged;
        }

        protected virtual void Update()
        {

        }

        protected virtual void OnDestroy()
        {
            healthStat.StatDepleted -= OnHealthDepleted;
            healthStat.StatChanged -= OnHealthChanged;
        }

        public void DamageAmount(float amount)
        {
            healthStat.BaseValue -= amount;
        }

        public void HealAmount(float amount)
        {
            healthStat.BaseValue += amount;
        }

        void OnHealthDepleted ()
        {

        }

        void OnHealthChanged (float before, float after)
        {

        }


        [Inspect]
        void TestDamage()
        {
            DamageAmount(1f);
        }
    } 
}
