using UnityEngine;
using System.Collections.Generic;
using System.Linq;

using Stats;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private List<Stat> stats = new List<Stat>();
    [SerializeField] private List<StatModifierGroup> modifiers = new List<StatModifierGroup>();

    // Adders and removers
    public void AddStat(Stat stat)
    {
        stats.Add(stat);
    }

    public void RemoveStat(StatType statType)
    {
        stats.RemoveAll(s => s.type == statType);
    }

    public void AddStatModifier(StatType statType, StatModifier modifier)
    {
        var group = modifiers.FirstOrDefault(g => g.statType == statType);
        if (group == null)
        {
            group = new StatModifierGroup { statType = statType };
            modifiers.Add(group);
        }

        group.modifiers.Add(modifier);
    }

    public void RemoveStatModifier(StatType statType, StatModifier modifier)
    {
        var group = modifiers.FirstOrDefault(g => g.statType == statType);
        if (group != null)
        {
            group.modifiers.Remove(modifier);
            if (group.modifiers.Count == 0)
                modifiers.Remove(group);
        }
    }

    // Finders
    public float GetUncomputedStatValue(StatType type)
    {
        var stat = stats.FirstOrDefault(s => s.type == type);
        if (stat != null)
            return stat.baseValue;

        Debug.LogError($"Stat of type {type} not found.");
        return -1f;
    }

    public float GetComputedStatValue(StatType type)
    {
        var stat = stats.FirstOrDefault(s => s.type == type);
        if (stat == null)
        {
            Debug.LogError($"Stat of type {type} not found.");
            return -1f;
        }

        float value = stat.baseValue;

        var group = modifiers.FirstOrDefault(g => g.statType == type);
        if (group != null)
        {
            foreach (var mod in group.modifiers)
            {
                value = mod.action switch
                {
                    StatModifierAction.Add => value + mod.value,
                    StatModifierAction.Remove => value - mod.value,
                    StatModifierAction.Multiply => value * mod.value,
                    StatModifierAction.Divide => value / mod.value,
                    _ => value
                };
            }
        }

        return value;
    }
}