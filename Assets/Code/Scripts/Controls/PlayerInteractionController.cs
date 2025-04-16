using Interactions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private InputActionReference interactAction;
        [SerializeField] private float interactionRadius = 1;
        [SerializeField] private float interactionDistance = 3;

        private IInteractable currentInteractable;
        private IHighlightable currentHighlightable;


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

        private void Update()
        {
            IHighlightable hitHighlightable = null;

            if (CheckCameraRaycast(out var interactable, out var highlightable))
            {
                currentInteractable = interactable;
                hitHighlightable = highlightable;
            }

            // Assign highlightable
            if (currentHighlightable == null && hitHighlightable != null)
            {
                currentHighlightable = hitHighlightable;
            }

            // Check if we can highlight or if we exit highlight
            if (currentHighlightable != null && hitHighlightable == null)
            {
                currentHighlightable.Unhighlight();
                currentHighlightable = null;
            }
            else if (currentHighlightable != null)
            {
                currentHighlightable.Highlight();
            }
        }

        private void InteractPerformed(InputAction.CallbackContext obj)
        {
            if (currentInteractable != null)
                currentInteractable.Interact();
        }

        private bool CheckCameraRaycast(out IInteractable interactable, out IHighlightable highlightable)
        {
            interactable = null;
            highlightable = null;

            if (Physics.Raycast(Player.Instance.playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f)),
                    out var hit, interactionDistance))
            {
                interactable = hit.collider.GetComponentInChildren<IInteractable>();
                highlightable = hit.collider.GetComponentInChildren<IHighlightable>();

                if (interactable != null) return true;
            }

            return false;
        }
    }
}