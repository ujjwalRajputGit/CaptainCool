using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float slideForce = 20f;
    public Animator animator;
    public Collider2D mainColider, slideColider;
    public TextMeshProUGUI gameOverText;
    public GameObject restartLevel;

    bool isGrounded;
    bool P_facingRight = true;
    bool jumpKeyDown;
    bool isSliding = false;
    bool slideKeyDown;
    float movement;

    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //getting the rigidBody.
        slideColider.enabled = false;
    }

    private void FixedUpdate()
    {
        //all physics related work done here.
        moveHorizontal();
        jump();
        slide();

    }

    private void Update()
    {
        
            //all input related work done here.
            movement = Input.GetAxisRaw("Horizontal");   //geting the input on horizontal axis.

            if (!jumpKeyDown && isGrounded)
            {
                jumpKeyDown = Input.GetButtonDown("Jump");   //checking for jump key down.
            }

            if (!slideKeyDown && isGrounded && Mathf.Abs(rb.velocity.x) > 0.05)
            {
                slideKeyDown = Input.GetKeyDown(KeyCode.S);   //checking for slide key down. 
            }
        

        if (movement > 0 && !P_facingRight)   //checking for player faceing direction.
        {
            Flip();
        }
        else if (movement < 0 && P_facingRight)
        {
            Flip();
        }

        if (!isGrounded && !isSliding)   //checking if the player is drooping
        {
            animator.SetBool("IsJumping", true);
        }

  


    }


    void slide()
    {
        if (slideKeyDown)
        {
            isSliding = true;
            animator.SetBool("IsSliding", true);
            if (P_facingRight)
            {
                rb.velocity = new Vector2(slideForce, 0f);
            }
            else if (!P_facingRight)
            {
                rb.velocity = new Vector2(-slideForce, 0f);
            }
            slideColider.enabled = true;
            mainColider.enabled = false;
            StartCoroutine("stopSliding");
        }
    }

    IEnumerator stopSliding()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsSliding", false);
        slideKeyDown = false;
        mainColider.enabled = true;
        slideColider.enabled = false;
        isSliding = false;
    }

    void jump()
    {
        if (jumpKeyDown && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);   //adding force to rigidBody.
                                                                            //rb.velocity = new Vector2(0f, jumpForce);

            animator.SetBool("IsJumping", true);   //enabling the jump animation.

            isGrounded = false;
            jumpKeyDown = false;
        }
    }

    void moveHorizontal()
    {
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);  //adding the velocity to the rigidBody
        animator.SetFloat("Speed", Mathf.Abs(movement));   //enabling or disabling run animation.
    }

    private void OnTriggerStay2D(Collider2D collision)  //checking the player it is grounded  or not.
    {
        if (collision != null && collision != cameraCollider.getCollider())
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);  //if player is grounded disabling the jump animation.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)   //checking for player to exit the ground.
    {
        isGrounded = false;
    }

    private void Flip()  //fliping the player direction.
    {
        P_facingRight = !P_facingRight;   // Switch the way the player is labelled as facing.

        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;   // Multiply the player's x local scale by -1.
        //transform.localScale = theScale;

        transform.Rotate(0f, 180f, 0f);
    }

    void dead() //calling through animation event(at end frame)
    {
        Destroy(gameObject);
        enablingUI();
    }

    void preDeath()  //calling through animation event(at end frame)
    {
        Destroy(gameObject, 1f);
        enablingUI();
    }

    void enablingUI()
    {
        gameOverText.enabled = true; //enabling the game over text
        restartLevel.SetActive(true); //enabling restart button
    }

}
