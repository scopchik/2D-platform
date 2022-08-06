using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public float startingHealth;
    public float currentHealth;
    public Animator anim;
    public bool dead;
    public float bossCurrentHealth;
    public float bossStartingHealth;
    public float enemyStartingHealth;
    public float enemyCurrentHealth;
    

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberOfflashes;
    private SpriteRenderer spriteRend;

    [Header ("Components")]
    public Behaviour[] components;

    public void Awake()
    {
        currentHealth = startingHealth;
        bossCurrentHealth = bossStartingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("Health") )
        {
            currentHealth = PlayerPrefs.GetFloat("Health");
        }
        
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        PlayerPrefs.SetFloat("Health", currentHealth);
        if(currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            //iframes
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                
                foreach(Behaviour component in components)
                {
                    component.enabled = false;
                }

                dead = true;
                
            }    
            
        }
        
        
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0 , startingHealth);
        PlayerPrefs.SetFloat("Health", currentHealth);
    }

    public void PlusHealth(float _value)
    {
        // startingHealth += 1;
        // PlayerPrefs.SetFloat("Health", startingHealth);
        // currentHealth = Mathf.Clamp(currentHealth + _value, 0 , startingHealth);
        // PlayerPrefs.SetFloat("Health", currentHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10,11, true);
        for (int i = 0; i < numberOfflashes; i++)
        {
            spriteRend.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfflashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfflashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10,11, false);
    }
    
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
