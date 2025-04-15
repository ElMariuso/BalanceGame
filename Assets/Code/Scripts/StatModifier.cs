using UnityEngine;
using System.Collections.Generic;

public enum StatModifierAction {
    Add,
    Remove,
    Multiply,
    Divide
}

[CreateAssetMenu(fileName = "NewStatModifier", menuName = "Stats/StatModifier")]
public class StatModifier: ScriptableObject
{
    public StatType type;
    public StatModifierAction action;
    public float value;
}

[System.Serializable]
public class StatModifierGroup
{
    public StatType statType;
    public List<StatModifier> modifiers = new List<StatModifier>();
}