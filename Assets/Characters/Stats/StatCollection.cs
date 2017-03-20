using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.RPGFramework
{
    [System.Serializable]
    public class StatCollection
    {
        [SerializeField]
        List<Stat> stats;

        [SerializeField]
        List<ModifierCollection> modifiers;

        public StatCollection ()
        {
            stats = new List<Stat>();
            modifiers = new List<ModifierCollection>();
        }

        public Stat GetOrAddStat(Stat newStat)
        {
            if (ContainsStat(newStat.Type))
                return GetStat(newStat.Type);
            else
            {
                stats.Add(newStat);
                return newStat;
            }
        }

        public Stat GetStat (StatType type)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                if (stats[i].Type == type)
                    return stats[i];
            }
            return null;
        }

        public bool ContainsStat (StatType type)
        {
            for (int i =0; i < stats.Count; i++)
            {
                if (stats[i].Type == type)
                    return true;
            }
            return false;
        }

        public void ProcessModifier (ModifierCollection mod)
        {
            for (int i = 0; i < mod.Modifiers.Count; i++)
            {
                GetStat(mod.Modifiers[i].StatEffected).ProcessModifier(mod.Modifiers[i]);
            }

            modifiers.Add(mod);
        }

        public void RemoveModifier (ModifierCollection mod)
        {
            for (int i = 0; i < mod.Modifiers.Count; i++)
            {
                ModifiableStat modStat = GetStat(mod.Modifiers[i].StatEffected) as ModifiableStat;

                if (modStat != null)
                    modStat.UndoModifier(mod.Modifiers[i]);
            }

            modifiers.Remove(mod);
        }

    } 
}
