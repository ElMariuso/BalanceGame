using Controls;
using Effects;
using Stats;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public PlayerStats stats;
    public PlayerEffectsController effects;
    public PlayerHealthController health;
    public Camera playerCamera;
    
    private void Awake()
    {
        // Poor singleton pattern but who cares
        if(Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }
}