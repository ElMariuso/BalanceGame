using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/NewWeapon")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public float damage;
        public string animationTrigger;
    }
}
