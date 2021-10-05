using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khemMovement : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField]
    float movementSpeed = 5;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    float gravity;

    bool Jump;
    float startVelocity;
    float crouchVelocity;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    
    public GameObject invisibleBody;
    public GameObject invisibleHair;
    public GameObject invisibleEyes;
    public GameObject invisibleTops;
    public GameObject invisibleShoes;
    public GameObject invisibleBottoms;
    
    public Transform cam;



    Vector3 moveDirection = Vector3.zero;



    Animator animator;


    void Start()
    {
        Jump           = false;
        animator       = GetComponent<Animator>();  //se inicia las animaciones
        controller     = GetComponent<CharacterController>();  //se inicia el character controller
        startVelocity  = movementSpeed;
        crouchVelocity = movementSpeed * 0.4f;

    }

    void Update()
    {
        float horizontal  = Input.GetAxisRaw("Horizontal");
        float vertical    = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        

        if (controller.isGrounded) //si esta tocando el suelo
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

            if (Input.GetKey(KeyCode.LeftControl)) //agacharse.    
            {
                animator.SetBool("crouch", true);

                movementSpeed = crouchVelocity;

                if (Input.GetMouseButtonDown(2))     //KeyCode.Mouse2) && Input.GetKey(KeyCode.LeftControl))   //si aprieta el boton del medio deja de moverse y SE TIENE QUE HACER INVISIBLE
                {
                    
                    movementSpeed  = 0f;
                    crouchVelocity = movementSpeed * 0f;
                    animator.SetBool("crouchIdle", true);
                    
                    invisibleBody.SetActive(false);
                    invisibleHair.SetActive(false);
                    invisibleTops.SetActive(false);
                    invisibleBottoms.SetActive(false);
                    invisibleEyes.SetActive(false);
                    invisibleShoes.SetActive(false);

                    Debug.Log("se hace invisible");
                }
                else if (Input.GetMouseButtonUp(2))
                {

                    movementSpeed = 5f;
                    crouchVelocity = movementSpeed * 0.4f;
                    animator.SetBool("crouchIdle", false);
                    
                    invisibleBody.SetActive(true);
                    invisibleHair.SetActive(true);
                    invisibleTops.SetActive(true);
                    invisibleBottoms.SetActive(true);
                    invisibleEyes.SetActive(true);
                    invisibleShoes.SetActive(true);

                }



            }
            else
            {
                animator.SetBool("crouch", false);

                movementSpeed = startVelocity;
            }


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

        if (Input.GetMouseButtonUp(2) || !Input.GetKey(KeyCode.LeftControl))
        {
            movementSpeed = crouchVelocity;
            animator.SetBool("crouchIdle", false);
            movementSpeed = 5f;
            crouchVelocity = movementSpeed * 0.4f;
            
            invisibleBody.SetActive(true);
            invisibleHair.SetActive(true);
            invisibleTops.SetActive(true);
            invisibleBottoms.SetActive(true);
            invisibleEyes.SetActive(true);
            invisibleShoes.SetActive(true);


        }



    }
    public void Falling()
    {
        animator.SetBool("Grounded", false);
        animator.SetBool("Jump", false);
    }
}
