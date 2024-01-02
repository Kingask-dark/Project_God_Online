using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        bool spacePressed = Input.GetKey(KeyCode.Space);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);

        if (!isWalking &&( forwardPressed || backwardPressed || leftPressed || rightPressed)){
            animator.SetBool(isWalkingHash, true);
        }
        
        if (isWalking && ( !forwardPressed || !backwardPressed || !leftPressed || !rightPressed)){
            animator.SetBool(isWalkingHash, false);
        }

        if(!isJumping && spacePressed){
            animator.SetBool(isJumpingHash,true);
        }
        if(isJumping && !spacePressed){
            animator.SetBool(isJumpingHash,false);
        }
    }
}
