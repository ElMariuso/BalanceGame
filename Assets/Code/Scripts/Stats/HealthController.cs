using UnityEngine;

namespace Stats
{
    public class HealthController : MonoBehaviour
    {
        public float maxHealth;
        public float currentHealth;

        private CharacterStats stats;
        
        private void Start()
        {
            stats = transform.parent.GetComponentInChildren<CharacterStats>();
            
            maxHealth = stats.GetComputedStatValue(StatType.Health);
            currentHealth = maxHealth;
            Debug.Log($"{transform.parent.name} Health: {currentHealth}/{maxHealth}");
            
            stats.OnStatChanged += OnStatChange;
        }

        private void OnDestroy()
        {
            if (stats != null) stats.OnStatChanged -= OnStatChange;
        }

        private void OnStatChange(StatType type)
        {
            if (type != StatType.Health) return;
            
            maxHealth = stats.GetComputedStatValue(StatType.Health);
            Debug.Log($"{transform.parent.name} Health: {currentHealth}/{maxHealth}");
        }

        public void ChangeHealth(float amount)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
            
            Debug.Log($"Amount: {amount}");
            Debug.Log($"{transform.parent.name} Health: {currentHealth}/{maxHealth}");
            
            if (currentHealth <= 0)
                Die();
        }
        
        private void Die()
        {
            Debug.Log($"{transform.parent.name} died.");
        }
    }
}