using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.RPGFramework
{

    [AdvancedInspector]
    [Serializable]
    public class ModifierGroup
    {
        [Inspect]
        [SerializeField]
        List<Modifier> modifiers = new List<Modifier>();
    }
}
