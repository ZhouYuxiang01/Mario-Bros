using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool facingRight = true;
    public PhysicsMaterial2D friction; 
    public PhysicsMaterial2D noFriction;
    private Animator animator;
    public Transform bottom;
    public AudioClip jumpSound;
    public GameManager gameManager;
    //public string deathSceneName = "DeathScene"; 
    //public string victorySceneName = "VictoryScene";


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().sharedMaterial = friction;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if Mario is grounded using Rigidbody2D's IsTouchingLayers method
        isGrounded = rb.IsTouchingLayers(groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            GetComponent<Rigidbody2D>().sharedMaterial = noFriction;
            GetComponent<AudioSource>().PlayOneShot(jumpSound);
        }
        if (transform.position.y < bottom.position.y)
        {
            animator.SetBool("IsDied", true);
            transform.Translate(Vector2.up * 2);
            gameManager.GameOver();
            //Debug.Log("Game Over"); 
            //SceneManager.LoadScene(DeathScene);
        }
        }
    

    private void FixedUpdate()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("horizontal",moveInput);
        // Flip Mario sprite if necessary
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
