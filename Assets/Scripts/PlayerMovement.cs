using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
   
   private void PlayerJump()
   {
       if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            PlayJumpAnim();
        }
   }

    private void PlayerWalk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        if (horizontalInput!= 0) PlayWalkAnim();
        ScaleFlip(horizontalInput);
    }

    private void ScaleFlip(float horizontalInput)
    {
        if (horizontalInput < 0) 
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }  
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }


    #region AnimationHandler

        private Animator animator;

        private void PlayWalkAnim()
        {
            animator.SetTrigger("goWalk");
        }

        private void PlayJumpAnim()
        {
            animator.SetTrigger("goJump");
        }
        
    #endregion

    void Update()
    {
        PlayerWalk();
        PlayerJump();
    }
}

