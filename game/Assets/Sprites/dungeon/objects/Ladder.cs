using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject btn;
    [SerializeField] private float speedUp;

    void Start()
    {
        body = GetComponent<PlayerMove>().rb;
        anim = GetComponent<PlayerMove>().anim;
        btn = GetComponent<GameObject>();
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if(other.gameObject.tag =="Ladder")
        {
            if(Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, speedUp);
                
            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -speedUp);
                
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
				
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = data.gravityScale;
    }
}
