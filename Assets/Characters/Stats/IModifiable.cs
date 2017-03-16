using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public interface IModifiable<T> : IStat<T> where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {
        T BaseValue { get; }

        Action<T, T> StatModified { get; set; }

        void OnModifierAdded(IModifier<T> modifier);
        void OnModifierRemoved(IModifier<T> modifier);
    }
}
