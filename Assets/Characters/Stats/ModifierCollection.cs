using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [System.Serializable]
    public class ModifierCollection
    {
        [SerializeField]
        string description = "Default Modifier";
        public string Description { get { return description; } }

        [SerializeField]
        List<Modifier> modifiers;
        public List<Modifier> Modifiers { get { return modifiers; } }

        public ModifierCollection(string description, params Modifier[] mods)
        {
            modifiers = new List<Modifier>();
            this.description = description;
            modifiers.AddRange(mods);
        }



    }
}
