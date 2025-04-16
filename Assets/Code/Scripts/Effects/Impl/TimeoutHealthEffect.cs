using Stats;
using UnityEngine;
using Utils;

namespace Effects.Impl
{
    public class TimeoutHealthEffect : TimeoutEffect
    {
        public float Health;
        public override void Apply(PlayerStats playerStats)
        {
            StaticCoroutine.Start(TimeoutEffectCoroutine(playerStats, OnTimeout));
        }

        private void OnTimeout()
        {
            Player.Instance.health.Heal(Health);
            Debug.Log($"[Timeout] Added {Health} HP.");
        }
    }
}