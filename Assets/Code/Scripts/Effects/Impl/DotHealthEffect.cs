using Stats;
using UnityEngine;
using Utils;

namespace Effects.Impl
{
    public class DotHealthEffect : DotEffect
    {
        public float Health;

        public override void Apply(PlayerStats playerStats)
        {
            StaticCoroutine.Start(DotEffectCoroutine(playerStats, OnDotAction));
        }

        private void OnDotAction()
        {
            Player.Instance.health.Heal(Health);
            Debug.Log($"[DOT] Added {Health} HP.");
        }
    }
}