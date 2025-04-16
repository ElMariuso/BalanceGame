using Interactions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private InputActionReference interactAction;
        [SerializeField] private float interactionRadius = 1;
        [SerializeField] private float interactionDistance = 3;
        private void OnEnable()
        {
            interactAction.action.Enable();
            interactAction.action.performed += InteractPerformed;
        }

        private void OnDisable()
        {
            interactAction.action.Disable();
            interactAction.action.performed -= InteractPerformed;
        }
        
        private void InteractPerformed(InputAction.CallbackContext obj)
        {
            if (CheckCameraRaycast(out var interactable))
            {
                interactable.Interact();
            }
        }

        private bool CheckCameraRaycast(out IInteractable interactable)
        {
            interactable = null;
            if (Physics.SphereCast(cam.transform.position, interactionRadius, 
                    cam.transform.forward, out var hit, interactionDistance))
            {
                interactable = hit.collider.GetComponentInChildren<IInteractable>();
                if (interactable != null) return true;
            }
            
            return false;
        }
    }
}