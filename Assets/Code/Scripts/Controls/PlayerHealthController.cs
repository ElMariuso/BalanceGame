using System;
using Stats;
using UnityEngine;

namespace Controls
{
    public class PlayerHealthController : MonoBehaviour
    {
        public float maxHealth;
        public float currentHealth;
        
        private void Start()
        {
            maxHealth = Player.Instance.stats.GetComputedStatValue(StatType.Health);
            currentHealth = maxHealth;
            Debug.Log($"Player health: {currentHealth}/{maxHealth}");
            
            Player.Instance.stats.OnStatChanged += OnStatChange;
        }

        private void OnDestroy()
        {
            Player.Instance.stats.OnStatChanged -= OnStatChange;
        }

        private void OnStatChange(StatType type)
        {
            if (type != StatType.Health) return;
            maxHealth = Player.Instance.stats.GetComputedStatValue(StatType.Health);
            
            Debug.Log($"Player health: {currentHealth}/{maxHealth}");
        }

        public void Heal(float amount)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
            
            Debug.Log($"Player health: {currentHealth}/{maxHealth}");
        }
    }
}