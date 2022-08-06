using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimLight : MonoBehaviour
{
    
    [SerializeField] private Animator fireLight;
    // Start is called before the first frame update
    void Start()
    {
        fireLight = GetComponent<Animator>();   
    }

    public void Fire()
    {
        fireLight.SetTrigger("light");  
    }
}
