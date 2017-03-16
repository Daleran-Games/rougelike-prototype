using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public interface IMaxRangeable<T> : IStat<T> where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {

        StatType MaxType { get; }
        T Max { get; }

        Action MaxReached { get; set; }
        Action<float,float> MaxStatChanged { get; set; }
    }
}
