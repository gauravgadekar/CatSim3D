using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTouchToMove : MonoBehaviour
{
    
    public GameManager gm;
    // Start is called before the first frame update
    private Touch touch;
    private Vector2 initPos;
    private Vector2 direction;
    public CharacterController characterController;
    private Vector3 moveDirection;
    public float speed = 5.0f;
    private bool canWalk = false;
    public float gravity = 10.0f;
    public float jumpForce = 3f;
    public float stopForce = 2f;
    public Animator animator;
    public GameObject jumpEffect;
    

    // Update is called once per frame
    void Update()
    {
        if (!gm.gameEnded && gm.gameStarted)
        {

            if (Input.touchCount > 0)
            {

                canWalk = true;
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    initPos = touch.position;
                }


                if (characterController.isGrounded)
                {
                    moveDirection = new Vector3(touch.position.x - initPos.x, 0, touch.position.y - initPos.y);

                    Quaternion targetRotation = moveDirection != Vector3.zero
                        ? Quaternion.LookRotation(moveDirection)
                        : transform.rotation;

                    transform.rotation = targetRotation;
                    moveDirection = moveDirection.normalized * speed;
                }
            }
            else
            {
                canWalk = false;
                moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, Time.deltaTime * stopForce);
            }

            animator.SetBool("canWalk", canWalk);

            if (Input.GetMouseButtonUp(0) && characterController.isGrounded)
            {
                Instantiate(jumpEffect, transform.position, Quaternion.identity);

                moveDirection.y = jumpForce;
            }

            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);


            characterController.Move(moveDirection * Time.deltaTime);
        }

    }
}

