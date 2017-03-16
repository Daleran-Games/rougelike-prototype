using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    public interface IChanger<T>  where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>
    {
        StatType StatEffected { get; }
        Operation ModifyBy { get; }
        T Amount { get; }
        Action<IChanger<T>> ChangeConsumed { get; set; }
    }
}
