using UnityEngine;

namespace Utils
{
    public class FaceCameraPlane : MonoBehaviour
    {
        void Update()
        {
            transform.forward = Player.Instance.playerCamera.transform.forward;
        }
    }
}
