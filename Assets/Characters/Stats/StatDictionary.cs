using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{

    [AdvancedInspector]
    [Serializable]
    public class StatDictionary : UDictionary<StatType,Stat>
    {

    }
}
