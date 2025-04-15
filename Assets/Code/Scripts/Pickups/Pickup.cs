using System;
using Effects;
using Effects.Impl;
using UnityEngine;

namespace Pickups
{
    public class Pickup : MonoBehaviour
    {
        private Effect effect;
        
        private void Start()
        {
            // effect = new InstantHealthEffect() { Health = 50 };
            effect = new DotHealthEffect() { Health = 50, Duration = 5, Rate = 0.5f };
        }
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Player.Instance.effects.ApplyEffect(effect);
            }
        }
    }
}