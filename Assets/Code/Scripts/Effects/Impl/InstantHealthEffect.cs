using Stats;
using UnityEngine;

namespace Effects.Impl
{
    public class InstantHealthEffect : InstantEffect
    {
        public float Health;

        public override void Apply(PlayerStats playerStats)
        {
            Player.Instance.health.Heal(Health);
            Debug.Log($"[Instant] Added {Health} HP");
        }
    }
}