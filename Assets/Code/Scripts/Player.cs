using Controls;
using Effects;
using Stats;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public CharacterStats stats;
    public PlayerEffectsController effects;
    public HealthController health;
    public Camera playerCamera;
    
    private void Awake()
    {
        // Poor singleton pattern but who cares
        if(Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }
}