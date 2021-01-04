using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 destination;

    public float jumpForce = 1f;
    public float walkSpeed = 2f;
    public float runSpeed = 6f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;

    public float turnSmoothTime = 0.1f; //number of seconds it takes for SmoothDampAngle from current value to the target value
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    private bool _isGrounded = true;
    private Transform _groundChecker;

    Animator animator;
    Transform cameraT;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cameraT = Camera.main.transform;
        _groundChecker = transform.GetChild(0);
    }

    
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        if (_isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        //Jumping animation rule
        if (Input.GetKeyDown(KeyCode.Space) && currentSpeed > 0.2f)
        {
            Jump();
            animator.SetBool("isJumping", true);
        }
        
        

        //Falling animation rule
        if (_isGrounded == false && rb.velocity.y < -2.5f)
        {
            animator.SetBool("isFalling", true);
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        //Player rotation
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        
        bool running = Input.GetKey(KeyCode.LeftShift);

        //Calculating player speed
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        //transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        //Controlling the animations
        float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        
    }

    void Jump()
    {
        if (_isGrounded == true)
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
       
    }
    
}
