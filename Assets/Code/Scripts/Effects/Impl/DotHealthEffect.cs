using Stats;
using UnityEngine;
using Utils;

namespace Effects.Impl
{
    [CreateAssetMenu(menuName = "Effects/DotHealth", fileName = "DotHealthEffect")]
    public class DotHealthEffect : DotEffect
    {
        public float health;

        public override void Apply(CharacterStats playerStats)
        {
            StaticCoroutine.Start(DotEffectCoroutine(playerStats, OnDotAction));
        }

        private void OnDotAction()
        {
            Player.Instance.health.ChangeHealth(health);
            Debug.Log($"[DOT] Added {health} HP.");
        }
    }
}