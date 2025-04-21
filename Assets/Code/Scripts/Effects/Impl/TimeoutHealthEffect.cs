using Stats;
using UnityEngine;
using Utils;

namespace Effects.Impl
{
    [CreateAssetMenu(menuName = "Effects/TimeoutHealth", fileName = "TimeoutHealthEffect")]
    public class TimeoutHealthEffect : TimeoutEffect
    {
        public float health;
        public override void Apply(CharacterStats playerStats)
        {
            StaticCoroutine.Start(TimeoutEffectCoroutine(playerStats, OnTimeout));
        }

        private void OnTimeout()
        {
            Player.Instance.health.ChangeHealth(health);
            Debug.Log($"[Timeout] Added {health} HP.");
        }
    }
}