using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class PlayerAttack : MonoBehaviour
    {
        [Header("Action References")]
        [SerializeField] private InputActionReference attackAction;
        [SerializeField] private InputActionReference parryAction;

        [Header("Tools")]
        [SerializeField] private MeleeWeapon weapon;

        private void OnEnable()
        {
            attackAction.action.Enable();
            parryAction.action.Enable();
        
            attackAction.action.performed += OnAttackPerformed;
            parryAction.action.performed += OnParryPerformed;
        }

        private void OnDisable()
        {
            attackAction.action.Disable();
            parryAction.action.Disable();
        
            attackAction.action.performed -= OnAttackPerformed;
            parryAction.action.performed -= OnParryPerformed;
        }
    
        private void OnAttackPerformed(InputAction.CallbackContext context)
        {
            HandleAttack();
        }
    
        private void HandleAttack()
        {
            weapon.HandleAttack();
        }

        private void OnParryPerformed(InputAction.CallbackContext context)
        {
            HandleParry();
        }

        private void HandleParry()
        {
            Debug.Log("PARRY");
        }
    }
}
