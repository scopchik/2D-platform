using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public float attackCooldown;
    public Animator anim;
    private PlayerMovement playerMovement;
    public float cooldownTimer = Mathf.Infinity;
    public Transform AttackPoint;
    [SerializeField] public float range;    
    public LayerMask enemyLayers;
    [SerializeField] public float damage;


    public void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void OnAttackButtonDown()
    {
        if(cooldownTimer > attackCooldown){
            Attack();
        }
        
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        //if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()){
        //    Attack();
        //}
        //cooldownTimer += Time.deltaTime;
    }

    public void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, range, enemyLayers);
        

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(damage);
        }

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BossHealth>().BossTakeDamage(damage);
        }
        
    }
    void DrawGizmosSelected()
    {
        if(AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, range);
    }
}
