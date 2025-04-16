using UnityEngine;

public class MeleeWeapon : Weapon
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void HandleAttack()
    {
        animator.SetTrigger("Attack");
    }
    
    public void OnAnimationEnd()
    {
        animator.SetTrigger("Reset");
    }
}
