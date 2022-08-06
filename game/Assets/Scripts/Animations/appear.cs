using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float time;
    public Animator anim;
    public float math;
    public float disappear = 1000;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Color newColor = new Color (1, 1, 1, 0);
        transform.GetComponent<Renderer>().material.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(time > math){
            StartCoroutine(FadeTo(1.0f, 1.0f));
            anim.SetBool("appear", true);
            time += Time.deltaTime; 
            
        }
        if(time > disappear)
        {
            StartCoroutine(FadeTo(0.0f, 1.0f));
            time += Time.deltaTime; 
        }
        
        time += Time.deltaTime; 
          
    }
    

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<Renderer>().material.color.a;
        
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color (1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
    }
    
}
