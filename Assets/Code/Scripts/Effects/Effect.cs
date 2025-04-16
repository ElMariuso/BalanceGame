using Stats;
using UnityEngine;

namespace Effects
{
    public abstract class Effect : ScriptableObject
    {
        public virtual void Apply(PlayerStats playerStats) { }
    }
}