using System;
using System.Collections;
using Stats;
using UnityEngine;

namespace Effects
{
    public abstract class DotEffect : Effect
    {
        public float duration;
        public float rate;
        
        public override void Apply(CharacterStats playerStats)
        {
            Debug.Log("Dot Effect");
        }

        public virtual IEnumerator DotEffectCoroutine(CharacterStats stats, Action onDot = null)
        {
            var t = 0f;
            while (t < duration)
            {
                yield return new WaitForSeconds(rate);
                onDot?.Invoke();
                t += rate;
            }
        }
    }
}