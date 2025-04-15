using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Action References")]
    [SerializeField] private InputActionReference attackAction;

    private void OnEnable()
    {
        attackAction.action.Enable();
        
        attackAction.action.performed += OnAttackPerformed;
    }

    private void OnDisable()
    {
        attackAction.action.Disable();
        
        attackAction.action.performed -= OnAttackPerformed;
    }
    
    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        HandleAttack();
    }
    
    private void HandleAttack()
    {
        Debug.Log("YAARRR");
    }
}
