using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour {

    [SerializeField]
    int playerEnergy = 150;
    public int PlayerEnergy
    {
        get { return playerEnergy; }
        set { playerEnergy = value; }
    }

    [SerializeField]
    int playerCondition = 8;
    public int PlayerCondition
    {
        get { return playerCondition; }
        set { playerCondition = value; }
    }


}
