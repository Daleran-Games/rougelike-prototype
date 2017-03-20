using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [CreateAssetMenu(fileName = "NewGameDatabase", menuName = "Data/Game Database", order = 98)]
    public class GameDatabase : ScriptableObject
    {
        [Header("Stat Types")]

        public StatType DefaultType;

        public StatType ActionTime;
        public StatType ActionTimer;

        public StatType Life;
        public StatType MaxLife;
        public StatType Armor;
        public StatType MaxArmor;

        public StatType Will;
        public StatType MaxWill;
        public StatType WillRate;

        public StatType Damage;
        public StatType AttackRange;

        public StatType MoveSpeed;

        public StatType Experience;
        public StatType MaxExperience;

        public StatType InventorySize;


    }

}
