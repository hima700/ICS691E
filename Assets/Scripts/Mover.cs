using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float gravity = -20f;
    [SerializeField] float jumpForce = 8f;

    CharacterController controller;
    float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -2f;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }
}


/**
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float rotationSpeed = 180f; // degrees per second
    [SerializeField] float gravity = -20f;
    [SerializeField] float jumpForce = 8f;

    CharacterController controller;
    float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // INPUT
        float moveInput = Input.GetAxis("Vertical");     // W / S
        float rotateInput = Input.GetAxis("Horizontal"); // A / D

        // ROTATION (turn left/right)
        transform.Rotate(Vector3.up * rotateInput * rotationSpeed * Time.deltaTime);

        // MOVEMENT (forward/backward relative to facing)
        Vector3 move = transform.forward * moveInput;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // GRAVITY & JUMP
        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -2f;

            if (Input.GetButtonDown("Jump"))
                verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }
}

    */
