using Stats;
using UnityEngine;

namespace Weapons
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private Collider hitbox;
        
        private float strength;

        private void Awake()
        {
            hitbox.enabled = false; // Be sure the hitbox is disabled by default
        }
        
        public override void HandleAttack(float attackStat)
        {
            strength = attackStat;
            
            animator.SetTrigger(weaponData.animationTrigger);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Player"))
            {
                other.GetComponentInParent<Enemy>().health.ChangeHealth(-DealDamage());
            }
        }
        
        protected override int DealDamage()
        {
            float strengthValue = Mathf.Max(strength, 1f);
            float weaponDamage = Mathf.Max(weaponData.damage, 1f);
            float weaponMass = Mathf.Max(weaponData.mass, 1f);

            return (int)(weaponDamage * (strengthValue / weaponMass) + 0.4f);
        }

        // Animation event
        public void HandleWeaponCollider(int isEnabled)
        {
            hitbox.enabled = (isEnabled == 1);
        }
    }
}