using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    // Rigidbody
    public Rigidbody2D Rigidbody2D = null;

    // Velocity
    private Vector3 velocity = Vector3.zero;

    [Header("Behaviour")]
    public float moveSpeedFactor = 10.0f;
    [Range(0, .3f)]
    public float moveDampFactor = 0.0f;

    [Header("Input")]
    [Range(-1f, 1f)]
    public float horizontalInput = 0f;

    [Header("Physics")]
    // Origin of the physics check to see if we are grounded
    public Transform groundChecker = null;
    public bool isGrounded = false;
    public LayerMask groundCheckLayersMask;
    public bool jumpInput = false;
    public float jumpForce = 800f;

    private Animator anim;
    
    void Start(){
        anim = GetComponent<Animator>();
        /*anim.SetBool("isGrounded", true);
        anim.SetBool("doublejump", false);*/
    }
    void Update()
    {
        // Get input 
       this.horizontalInput = Input.GetAxisRaw("Horizontal");
        //Input for jumping
       this.jumpInput = Input.GetKeyDown(KeyCode.UpArrow);

       // Switch player orientation depending on input
       this.HandleFlip();

        //jump
        if(this.jumpInput == true && this.isGrounded == true)
        {
            this.Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void FixedUpdate()
    {
        this.UpdateGroundStatus();
        this.HandleHorizontalMove();
    }

    private bool __FacingRight = true;

    private void HandleFlip()
    {
        // If the input is moving the player right and the player is facing left...
        if (this.horizontalInput > 0 && __FacingRight == false)
        {
            // Flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (this.horizontalInput < 0 && __FacingRight == true)
        {
            // Flip the player.
            Flip();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.groundChecker.transform.position, 0.2f);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        __FacingRight = !__FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 invertedScale = transform.localScale;
        invertedScale.x *= -1;

        // Apply
        transform.localScale = invertedScale;
    }


    // Ground check
    public void UpdateGroundStatus()
    {
        this.isGrounded = false;

        if(this.groundChecker != null)
        {
           Collider2D[] colliders =  Physics2D.OverlapCircleAll(this.groundChecker.transform.position,0.2f,this.groundCheckLayersMask);

           if(colliders != null && colliders.Length > 0)
           {
               for(int i=0; i<colliders.Length; i++)
               {
                   if(colliders[i].gameObject != this.gameObject)
                   {
                       //Debug.Log("")
                       this.isGrounded = true;
                   }

               }
           }
        }
    }

    // Movement
    private void HandleHorizontalMove()
    {
        if (this.Rigidbody2D != null)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(this.horizontalInput * this.moveSpeedFactor, this.Rigidbody2D.velocity.y);

            // And then smoothing it out and applying it to the character
            this.Rigidbody2D.velocity = Vector3.SmoothDamp(this.Rigidbody2D.velocity, targetVelocity, ref velocity, this.moveDampFactor);
        }
    }
}
