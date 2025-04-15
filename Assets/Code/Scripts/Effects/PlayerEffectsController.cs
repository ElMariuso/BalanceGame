using Stats;
using UnityEngine;

namespace Effects
{
    public class PlayerEffectsController : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        
        public void ApplyEffect(Effect effect)
        {
            effect.Apply(playerStats);
        }
    }
}