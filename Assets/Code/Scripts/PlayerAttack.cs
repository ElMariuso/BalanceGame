using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Action References")]
    [SerializeField] private InputActionReference attackAction;
    [SerializeField] private InputActionReference parryAction;

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
        Debug.Log("YAARRR");
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
