using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedUp;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    public Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    [SerializeField] private float normalSpeed;
    public float height;
    private float moveInput;
    [SerializeField] private float jump;

    [SerializeField] private Text coinsTaken;
    [SerializeField] private int coinValue;
    public int totalCoins = 0;

    public VectorValue pos;
    
    
    private void Awake()
    {
        
        
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("Coins") )
        {
            totalCoins = PlayerPrefs.GetInt("Coins");
            coinsTaken.text = "x " + totalCoins;
            
        }
        //transform.position = pos.initialValue; 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(moveInput * normalSpeed, body.velocity.y);
        if(isGrounded() == true && Input.GetKeyDown(KeyCode.Space))
        {
            jumpPower = jump;
            anim.SetTrigger("jump");
            body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("LadderUp");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger("LadderDown");
        }
        if(transform.position.y < height)
        {
            GetComponent<PlayerDeath>().PlayerDead();
        }

        if(speed > 0.01f){
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        } 
        else if(speed < -0.01f){
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }

        

        anim.SetBool("run", speed != 0);
        anim.SetBool("grounded", isGrounded());
        

        
    
        
    }
    // public void OnLadderUp()
    // {
    //     
    // }

    public void OnLeftButtonDown()
    {
        if(speed >= 0f)
        {
            speed = -normalSpeed;
        }
    }

    public void OnRightButtonDown()
    {
        if(speed <= 0f)
        {
            speed = normalSpeed;
        }
    }

    public void OnButtonUp()
    {
        speed = 0f;
    }

    public void OnJumpButtonDown()
    {
        
        if(isGrounded() == true)
        {
            jumpPower = jump;
            anim.SetTrigger("jump");
            body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    public void OnJumpButtonUp()
    {
        if(isGrounded() == false)
        {
            jumpPower = 0f;
        }
        if(wallJumpCooldown < 0.2f)
        {
            
            body.velocity = new Vector2(speed, body.velocity.y);
            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else 
            {
                body.gravityScale = 7;
            }
            
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }



    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    

    

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            TakeCoins();
            PlayerPrefs.SetInt("Coins", totalCoins);
            coinsTaken.text = "x " + totalCoins;
        }
    }
    

    public void TakeCoins()
    {
        totalCoins += coinValue;
    }
}
