using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public interface IStat<T> where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {
        StatType Type { get; }
        T Value { get; }
        Action<T, T> StatChanged { get; set; }

        void OnChangeRecieved(IChanger<T> change);
    }
}