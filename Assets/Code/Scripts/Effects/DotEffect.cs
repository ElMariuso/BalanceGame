using System;
using System.Collections;
using Stats;
using UnityEngine;

namespace Effects
{
    public abstract class DotEffect : Effect
    {
        public float Duration;
        public float Rate;
        
        public override void Apply(PlayerStats playerStats)
        {
            Debug.Log("Dot Effect");
        }

        public virtual IEnumerator DotEffectCoroutine(PlayerStats stats, Action onDot = null)
        {
            var t = 0f;
            while (t <= Duration)
            {
                yield return new WaitForSeconds(Rate);
                onDot?.Invoke();
                t += Rate;
            }
        }
    }
}