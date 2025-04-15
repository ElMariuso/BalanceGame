using System.Collections;
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
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float groundCheckDistance = 0.1f;
    
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
    private bool isDashing = false;
    
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
        if (isDashing) return;
        
        moveInput = moveAction.action.ReadValue<Vector2>();
        currentSpeed = sprintAction.action.IsPressed() ? sprintSpeed : moveSpeed;
    }

    private void FixedUpdate()
    {
        if (!isDashing && moveInput != Vector2.zero) Move();
        if (!isDashing && jumpAction.action.IsPressed() && IsGrounded()) Jump();
    }

    // Main movement utils functions
    private void Move()
    {
        Vector3 inputDirection = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 movement = player.transform.TransformDirection(inputDirection);
        Vector3 currentVelocity = rb.linearVelocity;
        
        rb.linearVelocity = new Vector3(movement.x * currentSpeed, currentVelocity.y, movement.z * currentSpeed);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private IEnumerator Dash(Vector2 direction)
    {
        isDashing = true;
        
        Vector3 dashDirection = new Vector3(direction.x, 0, direction.y).normalized;
        Vector3 movement = player.transform.TransformDirection(dashDirection);
        
        rb.linearVelocity = Vector3.zero;
        rb.linearVelocity = movement * dashForce;
        
        yield return new WaitForSeconds(0.2f);
        
        isDashing = false;
    }
    
    // Utils
    private void OnDash(InputAction.CallbackContext context)
    {
        if (context.interaction is MultiTapInteraction && !isDashing && moveInput != Vector2.zero)
        {
            Vector2 direction = moveInput.normalized;
            StartCoroutine(Dash(direction));
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(player.transform.position, Vector3.down, groundCheckDistance);
    }
}