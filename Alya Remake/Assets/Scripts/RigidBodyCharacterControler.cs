using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacterControler : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.5f;
    public LayerMask Ground;
    Vector3 _inputDir;

    public float turnSmoothTime = 0.1f; //number of seconds it takes for SmoothDampAngle from current value to the target value
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    Transform cameraT;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
        cameraT = Camera.main.transform;
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        _inputDir = _inputs.normalized;
        

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);

        //Calculating player speed
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * _inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        //Controlling the animations
        float animationSpeedPercent = ((running) ? 1 : 0.5f) * _inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);


    }


    void FixedUpdate()
    {
        //Player rotation
        if (_inputDir != Vector3.zero)
        {
            float targetRotation = Mathf.Atan2(_inputDir.x, _inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        _body.MovePosition(_body.position + _inputDir * currentSpeed * Time.fixedDeltaTime);
    }
}
