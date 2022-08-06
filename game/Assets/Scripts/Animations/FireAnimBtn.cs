using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimBtn : MonoBehaviour
{
    [SerializeField] private Animator btn;
    private int Clk;
    // Start is called before the first frame update
    public void Start()
    {
        btn = GetComponent<Animator>();
        
    }

    public void Fire()
    {
        if(Clk == 0)
        {
            btn.SetBool("isClicked", true);
            Clk = 1;
        }
        else if (Clk == 1)
        {
            btn.SetBool("isClicked", false);
            Clk = 0;
        }
    }
}
