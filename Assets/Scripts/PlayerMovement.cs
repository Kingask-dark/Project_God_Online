using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    public float speed = 0.1f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
 
        //right is the red Axis, foward is the blue axis
        // Vector3 move = transform.right * x + transform.forward * z;
        Vector3 direction = new Vector3(x,0f,z).normalized;
        if(direction.magnitude >= 0.1f){
            
        float targetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f,angle,0f);
        Vector3 movDirection = Quaternion.Euler(0f,targetAngle,0f)* Vector3.forward;
        controller.Move(speed * Time.deltaTime * movDirection.normalized);
    }
        }
}
