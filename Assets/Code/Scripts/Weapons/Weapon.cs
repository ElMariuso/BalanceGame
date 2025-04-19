using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected WeaponData weaponData;
        
        private void Awake()
        {
            if (animator == null) animator = GetComponent<Animator>();
        }
    
        public abstract void HandleAttack(float attackStat);
        protected abstract int DealDamage();

        public WeaponData GetWeaponData()
        {
            return weaponData;
        }
    }
}