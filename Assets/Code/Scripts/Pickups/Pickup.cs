using System;
using Effects;
using Effects.Impl;
using Interactions;
using UnityEngine;
using UnityEngine.Events;

namespace Pickups
{
    public class Pickup : MonoBehaviour, IInteractable
    {
        public Effect effect;
        public bool destroyOnPickup;
        public bool interactable;
        
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

        public void Interact()
        {
            Player.Instance.effects.ApplyEffect(effect);
            OnPickup?.Invoke();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (interactable) return;
            
            if (other.CompareTag("Player"))
            {
                Player.Instance.effects.ApplyEffect(effect);
                OnPickup?.Invoke();
            }
        }
    }
}