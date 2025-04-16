using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text healthText;
    
    void Update()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        healthBar.value = Player.Instance.health.currentHealth / Player.Instance.health.maxHealth;
        healthText.text = $"{Player.Instance.health.currentHealth}/{Player.Instance.health.maxHealth}";
    }
}
