using UnityEngine;
using UnityEngine.InputSystem;

public class  PlayerController: MonoBehaviour
{
    [Header("Referencias")]
    public Transform head; // Main Camera del XR Origin
    public CharacterController characterController;

    [Header("Input Actions")]
    public InputActionReference moveAction;   // Vector2
    public InputActionReference jumpAction;   // Button (X u O)

    [Header("Movimiento")]
    public float moveSpeed = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private float verticalVelocity;
    private bool isGrounded;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    private void Update()
    {
        CheckGround();
        HandleMovement();
        HandleJumpAndGravity();
    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
    }

    void HandleMovement()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 forward = head.forward;
        Vector3 right = head.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * input.y + right * input.x;

        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    void HandleJumpAndGravity()
    {
        if (jumpAction.action.WasPressedThisFrame() && isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 verticalMove = new Vector3(0, verticalVelocity, 0);
        characterController.Move(verticalMove * Time.deltaTime);
    }
}