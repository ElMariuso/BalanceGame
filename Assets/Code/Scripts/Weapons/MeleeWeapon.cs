namespace Weapons
{
    public class MeleeWeapon : Weapon
    {
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