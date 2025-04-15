using Effects;
using Stats;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public PlayerStats stats;
    public PlayerEffectsController effects;
    
    private void Awake()
    {
        // Poor singleton pattern but who cares
        if(Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }
}