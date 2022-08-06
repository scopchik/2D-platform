using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerButton : MonoBehaviour
{
    public GameObject button;

    public void Start()
    {
        button.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            button.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            button.SetActive(false);
        }
    }
}
