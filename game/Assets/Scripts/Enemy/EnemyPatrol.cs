using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;


    [Header ("Enemy")]
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLayer;
    private Health playerHealth;

    [Header ("Movement parameters")]
    public float speed;
    private Vector3 initScale;
    private bool movingLeft;
    [SerializeField] private Transform point;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float range;

    [Header ("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header ("Enemy Animator")]
    [SerializeField]private Animator anim;

    public bool chill = false;
    public bool angry = false;
    public float stoppingDistance;

    private void Awake()
    {
        initScale = enemy.localScale;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        range = leftEdge.position.x - rightEdge.position.x;
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void FixedUpdate()
    {
        Chill();
    }

    private void ChangeDirection()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration){
            movingLeft = !movingLeft;
        }
        
    }

    

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true); 
        //make enemy face in direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -(_direction), 
        initScale.y, initScale.z);
        //move
        enemy.position = new Vector3 (enemy.position.x + Time.deltaTime * _direction * speed,
        enemy.position.y, enemy.position.z);
    }

    private void Chill()
    {
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
            ChangeDirection();
            }
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                ChangeDirection();
            }
        }
        
    }

    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    
}
