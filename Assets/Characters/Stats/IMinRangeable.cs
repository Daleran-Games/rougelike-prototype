using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public interface IMinRangeable<T> : IStat<T> where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {
        StatType MinType { get; }
        T Min { get; }

        Action MinReached { get; set; }
        Action<float, float> MinStatChanged { get; set; }

    }
}
