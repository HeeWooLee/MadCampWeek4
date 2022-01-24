using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // adjustable variable ,by inspector > speed 
    [SerializeField] float _speed = 5f;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    // aim at ground, not walls or other npcs
    // [SerializeField] LayerMask _aimLayerMask;

    Rigidbody rigid;
    Animator _animator;
    bool isMoving;
    bool isJumping;
    bool isGrounded;
    bool isFalling;
    float gravityScale = 9.8f;
    float turnSpeed = 100.0f;

    // caching animator by GetComponent call and save in _animator
    void Awake() => _animator = GetComponent<Animator>();

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        rigid = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        rigid.AddForce(Physics.gravity * (gravityScale-1) * rigid.mass);
    }

    void OnCollisionStay()
    {

        _animator.SetBool("isJumping", false);
    }
    void Update()
    {
        // Jumping
        if (Input.GetButtonDown("Jump") && Input.GetButton("Jump"))
        {
            rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
            _animator.SetBool("isJumping", true);
        }

        // // aims toward the mouse 
        // AimTowardMouse();
        // Reading the Input 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("Horizontal " + horizontal);
        Debug.Log("Vertical " + vertical);

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        
        // Rotation

        // Moving
        if (movement.magnitude > 0)
        {
            // turn into direction
            movement.Normalize();
            // tie movement by frame rate
            movement *= _speed * Time.deltaTime;
            // move object in world space
            transform.Translate(movement, Space.World);
            transform.Rotate(Vector3.up * turnSpeed * horizontal * Time.deltaTime);
        }

        // Animating
        // tell if we are moving forward+/backward-
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        // tell if we are moving right+/left-
        // moves regardless of rotation, uses transform
        float velocityX = Vector3.Dot(movement.normalized, transform.right);

        // pass value to animator 
        // smooth out transition from running to idle motion / smooth blending
        _animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        _animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);        
    }
    // void AimTowardMouse()
    // {
    //     // gives a ray into the scene with mouse input
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     // mouse hit according to distance between camera and ground 
    //     if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _aimLayerMask))
    //     {
    //         // if we are over the ground
    //         // calculate direction by subtracting directions
    //         var _direction = hitInfo.point - transform.position;
    //         // flatten - keep spinning constraint for y axis
    //         _direction.y = 0f;
    //         // distance is not calculated but the direction is calculated
    //         _direction.Normalize();
    //         // set normalized direction to _direction
    //         transform.forward = _direction;
    //     }
    // }

}
