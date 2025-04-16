using Stats;
using UnityEngine;

namespace Effects.Impl
{
    [CreateAssetMenu(fileName = "StatModifierEffect", menuName = "Effects/StatModifierEffect")]
    public class StatModifierEffect : InstantEffect
    {
        public StatModifier modifier;
        
        public override void Apply(PlayerStats playerStats)
        {
            playerStats.AddStatModifier(modifier);
            Debug.Log($"[Instant] Added modifier {modifier}");
        }
    }
}