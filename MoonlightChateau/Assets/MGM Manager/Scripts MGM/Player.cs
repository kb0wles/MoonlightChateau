using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] int sprintMod;
    [SerializeField] int speed;
    [SerializeField] int gravity;


    Vector3 moveDirection;
    Vector3 playerVelocity;

    [SerializeField] float turnspeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Sprint();
        Turn();
    }

    void Movement()
    {
        if(controller.isGrounded)
        {
            playerVelocity = Vector3.zero;
        }
        else
        {
            playerVelocity.y = gravity * Time.deltaTime;
        }
        moveDirection = /*Input.GetAxis("Horizontal") * transform.right +*/ Input.GetAxis("Vertical") * transform.forward;
        controller.Move(moveDirection * speed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);

    }

    void Sprint()
    {
        if(Input.GetButtonDown("Sprint"))
        {
            speed *= sprintMod;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            speed /= sprintMod;
        }
    }

    void Turn()
    {
        float turn = Input.GetAxis("Horizontal") * turnspeed * Time.deltaTime;
        transform.Rotate(0f, turn, 0f);
    }

}
