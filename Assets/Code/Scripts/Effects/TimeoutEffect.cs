using System;
using System.Collections;
using Stats;
using UnityEngine;

namespace Effects
{
    public class TimeoutEffect : Effect
    {
        public float timeout;

        public override void Apply(CharacterStats playerStats)
        {
            Debug.Log("Timeout effect");
        }

        public virtual IEnumerator TimeoutEffectCoroutine(CharacterStats stats, Action onTimeout = null)
        {
            yield return new WaitForSeconds(timeout);
            onTimeout?.Invoke();
        }
    }
}