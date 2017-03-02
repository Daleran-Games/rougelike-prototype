using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class SaveData : MonoBehaviour
    {

        [SerializeField]
        float playerEnergy;
        public float SavedPlayerEnergy
        {
            get { return playerEnergy; }
            set { playerEnergy = value; }
        }

        [SerializeField]
        int playerCondition;
        public int SavedPlayerCondition
        {
            get { return playerCondition; }
            set { playerCondition = value; }
        }

        [SerializeField]
        int zone = 0;
        public int SavedZone
        {
            get { return zone; }
            set { zone = value; }
        }

        [SerializeField]
        float slowTimeScale = 0.05f;
        public float SlowTimeScale
        {
            get { return slowTimeScale; }
            set { slowTimeScale = value; }
        }


    } 
}
