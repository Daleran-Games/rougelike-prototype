﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [CreateAssetMenu(fileName = "NewGameDatabase", menuName = "Data/Game Database", order = 98)]
    public class GameDatabase : ScriptableObject
    {
        [Header("Stat Types")]
        public StatType DefaultStatType;
        public StatType ActionTime;
        public StatType ActionTimer;
        public StatType Armor;
        public StatType Chance;
        public StatType Condition;
        public StatType CPUSpeed;
        public StatType Damage;
        public StatType DamageSelf;
        public StatType Energy;
        public StatType EnergyCost;
        public StatType EnergyGeneration;
        public StatType EnergyUse;
        public StatType Range;
        public StatType Repair;
        public StatType Speed;
        public StatType StopsMovement;

    }

}
