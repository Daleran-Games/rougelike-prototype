using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public abstract class GameState : MonoBehaviour
    {

        public StateChangeHandler StateEnabled;
        public StateChangeHandler StateDisabled;

    } 
}
