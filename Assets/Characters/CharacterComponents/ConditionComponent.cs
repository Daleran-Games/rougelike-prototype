using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.RPGFramework;

namespace DaleranGames.Characters
{
    public class ConditionComponent : CharacterComponent
    {
        public ScaleFloatStat Condition;
        public FloatStat ActionTime;
        public FloatStat MovementSpeed;
        public BoolStat IsBeingHit;

        public Color32 RepairColor;
        public Color32 DamageColor;
        public Color32 DeadColor;
        public AudioClip[] HitSounds;

    } 
}
