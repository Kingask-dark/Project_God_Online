using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float speed = 0.1f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isGrounded;
    // Update is called once per frame

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Vector3 direction = new Vector3(x,0f,z).normalized;
        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            Vector3 movDirection = Quaternion.Euler(0f,targetAngle,0f)* Vector3.forward;
            controller.Move(speed * Time.deltaTime * movDirection.normalized);
        }

        if(controller.isGrounded){
            float groundedGravity = -.05f;
            direction.y = groundedGravity;            
        }
        else{
            direction.y += gravity;
        }

        //  if(isGrounded && direction.y < 0){
        //     direction.y = -2f;
        // }
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
           direction.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        controller.Move(direction * Time.deltaTime);
    }
}
