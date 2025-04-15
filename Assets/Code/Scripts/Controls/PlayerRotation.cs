using UnityEngine;

namespace Controls
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform bodyTransform;

        private Vector3 lookDirection;
        private Quaternion targetRotation;
    
        private void LateUpdate()
        {
            lookDirection = cameraTransform.forward;
            lookDirection.y = 0;
            lookDirection.Normalize();

            if (lookDirection != Vector3.zero)
            {
                targetRotation = Quaternion.LookRotation(lookDirection);
                bodyTransform.rotation = targetRotation;
            }
        }
    }
}
