using UnityEngine;

namespace Weapons
{
    public enum WeaponClass
    {
        Melee,
        Distance,
        Magic
    }
    
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/NewWeapon")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public WeaponClass weaponClass;
        
        public float damage = -1f;
        public float mass = -1f;
        
        public string animationTrigger;
    }
}
