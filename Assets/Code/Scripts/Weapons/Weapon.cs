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
    
        public abstract void HandleAttack();

        protected virtual void DealDamage()
        {
            Debug.Log("DealDamage " + weaponData.damage);
        }
    }
}