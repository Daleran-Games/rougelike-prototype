using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public interface IModifiable
    {

        Action<float, float> StatModified { get; set; }

        void AddModifier(Modifier mod);
        void RemoveModifier(Modifier mod);
        void ClearModifiers();

    }
}
