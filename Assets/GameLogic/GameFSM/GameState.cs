using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DaleranGames.ElectricDreams
{
    public abstract class GameState : MonoBehaviour
    {

        public StateChangeHandler StateEnabled;
        public StateChangeHandler StateDisabled;

    } 
}
