using Stats;
using UnityEngine;

namespace Effects.Impl
{
    public class InstantHealthEffect : InstantEffect
    {
        public float Health;

        public override void Apply(PlayerStats playerStats)
        {
            // TODO: Add health to the player
            Debug.Log($"[Instant] Added {Health} HP");
        }
    }
}