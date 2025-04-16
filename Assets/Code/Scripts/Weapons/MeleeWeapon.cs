using UnityEngine;

namespace Weapons
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private Collider hitbox;
        
        public override void HandleAttack()
        {
            animator.SetTrigger("Attack");
            DealDamage();
        }
        
        protected override void DealDamage()
        {
            base.DealDamage();
        }
    }
}