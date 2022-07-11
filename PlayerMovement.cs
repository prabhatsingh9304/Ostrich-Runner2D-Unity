using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D player;
    [SerializeField] float speed=1f;
    [SerializeField] float jumpSpeed = 2f;
    private Animator playerAnim;
    private bool isGrounded;
    private float character_xScale;                                                         // For storing the scale of player

    private float horizontalInput;
    private bool m_facingRight = true; //Facing of player

    private void Awake()
    {
        character_xScale = transform.localScale.x;
        player = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(KeyCode.A)){
            playerAnim.SetBool("isWalking",true);                                                      // For left Movement
            transform.localScale = new Vector2(-1 * character_xScale,transform.localScale.y);             // Fliping of Character toward left
            player.velocity = speed * Vector2.left;

        }
        else if(Input.GetKey(KeyCode.D )){
            playerAnim.SetBool("isWalking",true);                                                     //For Right Movement
            transform.localScale = new Vector2(character_xScale,transform.localScale.y);
            player.velocity = speed * Vector2.right;
        }*/
        horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0f && !m_facingRight)
        {
            //transform.localScale = new Vector2(character_xScale,transform.localScale.y);
            Flip();
            
        }
        else if(horizontalInput < 0f && m_facingRight)
        {
            //transform.localScale = new Vector2(-1 * character_xScale,transform.localScale.y);            
            Flip();
        }
        player.velocity = new Vector2( horizontalInput * speed,player.velocity.y);
        playerAnim.SetBool("isWalking",horizontalInput != 0);
        playerAnim.SetBool("isGrounded",isGrounded);

        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){                                        // Jumping 
            Jump();
        }
                   
    }
    
    private void Jump(){
        player.velocity = new Vector2(player.velocity.x,jumpSpeed);
        playerAnim.SetTrigger("jump");
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "ground"){
            isGrounded = true;
        }
    }

    void Flip(){
        m_facingRight = !m_facingRight;
        transform.Rotate(0f,180f,0f);
    }
}
