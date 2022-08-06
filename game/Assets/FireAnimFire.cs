using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimFire : MonoBehaviour
{
    [SerializeField] private Animator fire;
    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Fire()
    {
        fire.SetTrigger("fire"); 
    }
}
