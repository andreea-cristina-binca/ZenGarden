using UnityEngine;


public class Player : MonoBehaviour
{
    public static float GRAVITY = -9.81f;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpSpeed = 1f;
    [SerializeField] private float groundDistance = 0.4f;

    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    public Animator animator;
    
    private Vector3 oldPosition;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isJumping;

    private void Start()
    {
        oldPosition = transform.position;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * GRAVITY);
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        velocity.y += GRAVITY * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Animation Triggers
        if (transform.position.x == oldPosition.x && transform.position.z == oldPosition.z)
        {
            animator.SetBool("isWalking", false);
            if (isJumping)
                animator.SetBool("isJumping", true);
            else
                animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            oldPosition = transform.position;

            if (isJumping)
                animator.SetBool("isJumping", true);
            else
                animator.SetBool("isJumping", false);
        }
    }
}
