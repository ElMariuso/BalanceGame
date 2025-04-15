using Stats;
using UnityEngine;

namespace Effects
{
    public abstract class InstantEffect : Effect
    {
        public override void Apply(PlayerStats playerStats)
        {
            Debug.Log("Instant effect");
        }
    }
}