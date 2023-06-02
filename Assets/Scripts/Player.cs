using UnityEngine;


public class Player : MonoBehaviour
{
    public static float GRAVITY = -9.81f;

    [SerializeField] private float moveSpeed = 3f;
    // [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float jumpSpeed = 1f;
    [SerializeField] private float groundDistance = 0.4f;

    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    // [SerializeField] private UI_Inventory uiInventory;
    
    private Vector3 velocity;
    private bool isGrounded;
    private bool isWalking;

    private Inventory inventory;

    private void Start()
    {
        inventory = new Inventory();
        // uiInventory.setInventory(inventory);
    }

    void Update()
    {
        //Vector2 inputVector = GameInput.Instance.GetMovementVector();

        //Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        //transform.position += moveDir * moveSpeed * Time.deltaTime;

        //isWalking = moveDir != Vector3.zero;

        //transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

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
        }

        velocity.y += GRAVITY * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
