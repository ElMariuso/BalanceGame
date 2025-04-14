using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dashForce = 5f;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce = 100f;
    
    [Header("Action References")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference sprintAction;
    [SerializeField] private InputActionReference dashAction;
    [SerializeField] private InputActionReference jumpAction;

    private Rigidbody rb;
    
    // Movement
    private Vector2 moveInput;
    private float currentSpeed;
    private float sprintSpeed;
    
    // Setup
    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();

        currentSpeed = moveSpeed;
        sprintSpeed = moveSpeed * 2;
    }
    
    private void OnEnable()
    {
        moveAction.action.Enable();
        sprintAction.action.Enable();
        dashAction.action.Enable();
        jumpAction.action.Enable();
        
        dashAction.action.performed += OnDash;
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        sprintAction.action.Disable();
        dashAction.action.Disable();
        jumpAction.action.Disable();
        
        dashAction.action.performed -= OnDash;
    }

    // Runtime
    private void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
        currentSpeed = sprintAction.action.IsPressed() ? sprintSpeed : moveSpeed;
    }

    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero) Move();
    }

    // Main movement utils functions
    private void Move()
    {
        Vector3 inputDirection = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 movement = player.transform.TransformDirection(inputDirection);
        rb.linearVelocity = movement * currentSpeed;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Dash(Vector2 direction)
    {
        Vector3 dashDirection = new Vector3(direction.x, 0, direction.y);
        Vector3 movement = player.transform.TransformDirection(dashDirection);
        
        rb.AddForce(movement * dashForce, ForceMode.Impulse);
    }
    
    // Utils
    private void OnDash(InputAction.CallbackContext context)
    {
        if (context.interaction is MultiTapInteraction)
        {
            Vector2 direction = moveInput.normalized;
            Dash(direction);
        }
    }
}