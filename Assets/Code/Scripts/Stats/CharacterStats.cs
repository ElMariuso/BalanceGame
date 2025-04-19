using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Stats
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] private List<Stat> stats = new List<Stat>();
        [SerializeField] private List<StatModifierGroup> modifiers = new List<StatModifierGroup>();

        public event Action<StatType> OnStatChanged;

        // Adders and removers
        public void AddStat(Stat stat)
        {
            if (stat == null)
            {
                Debug.LogWarning("Tried to add a null Stat.");
                return;
            }
            
            stats.Add(stat);
        }

        public void RemoveStat(StatType statType)
        {
            int removedCount = stats.RemoveAll(s => s.type == statType);

            if (removedCount == 0)
            {
                Debug.LogWarning($"Tried to remove stat of type {statType}, but it wasn't found.");
            }
        }

        public void AddStatModifier(StatModifier modifier)
        {
            if (modifier == null)
            {
                Debug.LogWarning("Tried to add a null StatModifier.");
                return;
            }
            
            var group = modifiers.FirstOrDefault(g => g.statType == modifier.type);
            
            // If the group doesn't exist, create it and add it
            if (group == null)
            {
                group = new StatModifierGroup { statType = modifier.type };
                modifiers.Add(group);
            }

            // Add the modifier to the group and invoke event
            group.modifiers.Add(modifier);
            OnStatChanged?.Invoke(modifier.type);
        }

        public void RemoveStatModifier(StatModifier modifier)
        {
            if (modifier == null)
            {
                Debug.LogWarning("Tried to remove a null StatModifier.");
                return;
            }
            
            var group = modifiers.FirstOrDefault(g => g.statType == modifier.type);
            
            if (group != null)
            {
                group.modifiers.Remove(modifier);
                
                // Remove group if empty
                if (group.modifiers.Count == 0)
                    modifiers.Remove(group);
            }

            OnStatChanged?.Invoke(modifier.type); // Invoke event
        }
        
        public void AddStatModifierGroup(StatModifierGroup modifierGroup)
        {
            if (modifierGroup == null)
            {
                Debug.LogWarning("Tried to add a null StatModifierGroup.");
                return;
            }

            if (modifierGroup.modifiers == null || modifierGroup.modifiers.Count == 0)
            {
                Debug.LogWarning($"Tried to add empty StatModifierGroup for {modifierGroup.statType}.");
                return;
            }

            var group = modifiers.FirstOrDefault(g => g.statType == modifierGroup.statType);

            if (group == null) modifiers.Add(modifierGroup); // If the group doesn't exist, create it and add it
            else group.modifiers.AddRange(modifierGroup.modifiers); // If not, merge the two lists
            
            OnStatChanged?.Invoke(modifierGroup.statType);
        }
        
        public void RemoveStatModifierGroup(StatType statType)
        {
            var group = modifiers.FirstOrDefault(g => g.statType == statType);

            if (group != null)
            {
                modifiers.Remove(group);
                OnStatChanged?.Invoke(statType);
            }
        }
        
        // Getters
        private Stat GetStat(StatType statType)
        {
            return stats.FirstOrDefault(s => s.type == statType);
        }
        
        private StatModifierGroup GetModifierGroup(StatType statType)
        {
            return modifiers.FirstOrDefault(g => g.statType == statType);
        }
        
        private StatModifier GetModifier(StatType statType, StatModifier targetModifier)
        {
            var group = GetModifierGroup(statType);
            return group?.modifiers.FirstOrDefault(m => m == targetModifier);
        }

        // Finders
        public float GetUncomputedStatValue(StatType type)
        {
            var stat = stats.FirstOrDefault(s => s.type == type);
            if (stat != null)
                return stat.baseValue;

            Debug.LogWarning($"Stat of type {type} not found.");
            return -1f;
        }

        public float GetComputedStatValue(StatType type)
        {
            var stat = stats.FirstOrDefault(s => s.type == type);
            if (stat == null)
            {
                Debug.LogWarning($"Stat of type {type} not found.");
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
}