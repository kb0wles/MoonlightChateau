using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] CharacterController controller;


    [SerializeField] int sprintspeed;
    [SerializeField] int speed;
    [SerializeField] int gravity;

    Vector3 moveDirection;
    Vector3 playerVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
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
        moveDirection = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        controller.Move(moveDirection * speed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);

    }


}
