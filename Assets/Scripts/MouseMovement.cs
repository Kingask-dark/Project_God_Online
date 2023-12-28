using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        // we clamp the rotation so we cant over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        // control rotation around y axis(look up and down)
        yRotation += mouseX;
        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0f); 
    }
}
