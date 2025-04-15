using UnityEngine;

public enum StatType
{
    Health,
    Stamina,
    Speed,
}

[CreateAssetMenu(fileName = "NewStat", menuName = "Stats/Stat")]
public class Stat : ScriptableObject
{
    public string statName;
    public StatType type;
    public float baseValue;
}

