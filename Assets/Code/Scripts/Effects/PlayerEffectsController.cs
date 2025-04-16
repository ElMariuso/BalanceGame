using Stats;
using UnityEngine;

namespace Effects
{
    public class PlayerEffectsController : MonoBehaviour
    {
        public void ApplyEffect(Effect effect)
        {
            effect.Apply(Player.Instance.stats);
        }
    }
}