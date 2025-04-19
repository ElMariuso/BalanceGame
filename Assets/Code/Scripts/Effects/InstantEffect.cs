using Stats;
using UnityEngine;

namespace Effects
{
    public abstract class InstantEffect : Effect
    {
        public override void Apply(CharacterStats playerStats)
        {
            Debug.Log("Instant effect");
        }
    }
}