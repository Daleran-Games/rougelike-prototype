using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.ElectricDreams
{
    public class StopsMovement : Stat<bool>
    {

        public StopsMovement(bool amount)
        {
            StatValue = amount;
            TypeStat = GetStatType("Stops Movement");
        }
    } 
}
