using System;
using System.Collections;
using Stats;
using UnityEngine;

namespace Effects
{
    public class TimeoutEffect : Effect
    {
        public float Timeout;

        public override void Apply(PlayerStats playerStats)
        {
            Debug.Log("Timeout effect");
        }

        public virtual IEnumerator TimeoutEffectCoroutine(PlayerStats stats, Action onTimeout = null)
        {
            yield return new WaitForSeconds(Timeout);
            onTimeout?.Invoke();
        }
    }
}