using System;
using Effects;
using Effects.Impl;
using Interactions;
using UnityEngine;
using UnityEngine.Events;

namespace Pickups
{
    public class Pickup : MonoBehaviour, IInteractable, IHighlightable
    {
        public Effect effect;
        public bool destroyOnPickup;
        public bool interactable;
        
        public bool hasTooltip;
        public Transform tooltipAttach;
        public GameObject tooltipPrefab;
        
        protected UnityAction OnPickup;

        private GameObject currentTooltip;
        
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
            if (destroyOnPickup) Destroy(gameObject);
        }

        public void Interact()
        {
            if (!interactable) return;

            Player.Instance.effects.ApplyEffect(effect);
            OnPickup?.Invoke();
        }

        public void Highlight()
        {
            if (!hasTooltip) return;
            if (currentTooltip == null)
            {
                currentTooltip = Instantiate(tooltipPrefab, tooltipAttach);
            }
        }

        public void Unhighlight()
        {
            if (!hasTooltip) return;
            if (!this)
            {
                // Prevent null ex on unhighlight a picked up object
                return;
            }
            Destroy(currentTooltip);
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