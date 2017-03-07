using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    [CreateAssetMenu(fileName = "NewGameDatabase", menuName = "Data/Game Database", order = 98)]
    public class GameDatabase : ScriptableObject
    {
        [Header("Stat Types")]
        public List<StatType> StatTypes = new List<StatType>();
        
    }

}
