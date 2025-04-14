using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce = 100f;
    
    [Header("Actions")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference sprintAction;
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
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        sprintAction.action.Disable();
        jumpAction.action.Disable();
    }

    // Runtime
    private void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
        currentSpeed = sprintAction.action.IsPressed() ? sprintSpeed : moveSpeed;
    }

    private void FixedUpdate()
    {
        Move();
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
}