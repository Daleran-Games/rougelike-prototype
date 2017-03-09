using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Items
{
    [CreateAssetMenu(fileName = "NewItemType", menuName = "Data/ItemType", order = 101)]
    public class ItemType : ScriptableObject
    {
        public string itemName;

    } 
}
