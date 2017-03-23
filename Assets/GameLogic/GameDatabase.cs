using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [CreateAssetMenu(fileName = "NewGameDatabase", menuName = "Data/Game Database", order = 98)]
    public class GameDatabase : ScriptableObject
    {
        [Header("Stat Types")]

        public StatAsset DefaultType;

        public StatAsset ActionTime;
        public StatAsset ActionTimer;

        public StatAsset Life;
        public StatAsset MaxLife;
        public StatAsset Armor;
        public StatAsset MaxArmor;

        public StatAsset Will;
        public StatAsset MaxWill;
        public StatAsset WillRate;

        public StatAsset Damage;
        public StatAsset AttackRange;

        public StatAsset MoveSpeed;

        public StatAsset Experience;
        public StatAsset MaxExperience;

        public StatAsset InventorySize;


    }

}
