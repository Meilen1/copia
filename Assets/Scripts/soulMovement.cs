using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulMovement : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField]
    float movementSpeed = 5;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    float gravity;
    bool Jump;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;



    Vector3 moveDirection = Vector3.zero;



    Animator animator;


    void Start()
    {
        Jump       = false;
        animator   = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal  = Input.GetAxisRaw("Horizontal");
        float vertical    = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (controller.isGrounded)
        {


            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("Jump", true);
                moveDirection.y = jumpSpeed;
            }
            else
            {
                animator.SetBool("Jump", false);
            }


            animator.SetBool("Grounded", true);



        }
        else
        {
            Falling();
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle  = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle        = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir    = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(moveDir * movementSpeed * Time.deltaTime);
        }


        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        animator.SetFloat("VelX", Input.GetAxis("Horizontal"));
        animator.SetFloat("VelY", Input.GetAxis("Vertical"));

    }
    public void Falling()
    {
        animator.SetBool("Grounded", false);
        animator.SetBool("Jump", false);
    }
}
