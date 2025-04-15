using Stats;

namespace Effects
{
    public abstract class Effect
    {
        public EffectType Type;

        public virtual void Apply(PlayerStats playerStats) { }
    }

    public enum EffectType
    {
        Instant, Dot, Timeout
    }
}