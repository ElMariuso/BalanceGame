using Stats;
using UnityEngine;

namespace Effects.Impl
{
    [CreateAssetMenu(menuName = "Effects/InstantHealth", fileName = "InstantHealthEffect")]
    public class InstantHealthEffect : InstantEffect
    {
        public float health;

        public override void Apply(PlayerStats playerStats)
        {
            Player.Instance.health.Heal(health);
            Debug.Log($"[Instant] Added {health} HP");
        }
    }
}