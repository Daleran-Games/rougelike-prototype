using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.RPGFramework
{
    public class EnergyComponent : DynamicRangeComponent
    {

        [SerializeField]
        Color32 chargeColor = ColorExtensions.white;
        [SerializeField]
        AudioClip[] chargeSounds;


        void Awake()
        {
            Scale = new ModifiableScaleFloatStat(GameManager.Instance.Database.Energy, GameManager.Instance.Database.MaxEnergy, Scale.Value, Scale.BaseValue);
            Rate = new ModifiableFloatStat(GameManager.Instance.Database.EnergyRate, Rate.BaseValue);
        }

        protected override void Update()
        {
            base.Update();
        }

          

    }
}
