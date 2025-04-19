using Stats;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Controls
{
    public class PlayerAttack : MonoBehaviour
    {
        [Header("Action References")]
        [SerializeField] private InputActionReference attackAction;
        [SerializeField] private InputActionReference parryAction;

        [Header("Tools")]
        [SerializeField] private Weapon weapon;

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
            float attackStat = weapon.GetWeaponData().weaponClass switch
            {
                WeaponClass.Melee => Player.Instance.stats.GetComputedStatValue(StatType.Strength),
                _ => 1f
            };
            weapon.HandleAttack(attackStat);
        }

        private void OnParryPerformed(InputAction.CallbackContext context)
        {
            Debug.Log("PARRY");
        }
    }
}
