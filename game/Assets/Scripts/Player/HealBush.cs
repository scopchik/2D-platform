using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBush : MonoBehaviour
{
    [SerializeField] private float healTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healTaken);
            // anim.SetTrigger("disappear");
            Destroy(this.gameObject); 
        }
    }    
}
