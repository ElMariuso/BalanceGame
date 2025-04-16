using System;
using Effects;
using Effects.Impl;
using UnityEngine;
using UnityEngine.Events;

namespace Pickups
{
    public class Pickup : MonoBehaviour
    {
        public Effect effect;
        public bool destroyOnPickup;
        
        protected UnityAction OnPickup;

        private void OnEnable()
        {
            OnPickup += PickedUp;
        }

        private void OnDisable()
        {
            OnPickup -= PickedUp;
        }
        
        private void PickedUp()
        {
            if(destroyOnPickup) Destroy(gameObject);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Player.Instance.effects.ApplyEffect(effect);
                OnPickup?.Invoke();
            }
        }
    }
}