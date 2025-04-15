namespace Stats
{
    public enum StatType
    {
        Health,
        Stamina,
        Speed,
    }

    [System.Serializable]
    public class Stat
    {
        public string statName;
        public StatType type;
        public float baseValue;
    }
}