using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    
    [SerializeField] float moveInput;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 18;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;

    [SerializeField]  Animator myAnimator;
    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;

    void Start() {
        if(rigid == null) {
            rigid = GetComponent<Rigidbody2D>();
        }
        if(myAnimator == null) {
            myAnimator = GetComponent<Animator>();
        }
        myAnimator.SetInteger("AnimationState", IDLE);
    }

    void Update() {
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetKey("w"))
            jumpPressed = true;
    }

    void FixedUpdate() {
        rigid.velocity = new Vector2(SPEED * moveInput, rigid.velocity.y);
        //This will spawn the player on the opposite side of the ground if they went out of bounds
        if(transform.position.x < -52) {
            transform.position = new Vector3(56, transform.position.y, 0);
        }
        else if(transform.position.x > 62) {
            transform.position = new Vector3(-46, transform.position.y, 0);
        }
        if (moveInput < 0 && isFacingRight || moveInput > 0 && !isFacingRight) {
            Flip();
        }
        if (jumpPressed && isGrounded) {
            Jump();
        }
        else {
            jumpPressed = false;
            if(isGrounded) {
                if (moveInput > 0 || moveInput < 0)
                {
                    myAnimator.SetInteger("AnimationState", RUN);
                }
                else {
                    myAnimator.SetInteger("AnimationState", IDLE);
                }
            }
        }

    }

    private void Flip() {
        transform.Rotate(0, -180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump() {
        myAnimator.SetInteger("AnimationState", JUMP);
        rigid.velocity = new Vector2(rigid.velocity.x , 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = true;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "platform") {
            isGrounded = true;
        }
    }
}
