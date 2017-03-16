using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public interface IModifier<T> where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {
        string Description { get; }
        StatType StatEffected { get; }
        Operation ModifyBy { get; }
        T Amount { get; }
    }

    public enum Operation
    {
        Add,
        Multiply,
        Set
    }
}
