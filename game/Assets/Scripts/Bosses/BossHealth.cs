using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Health
{
    


    public void BossTakeDamage(float _damage)
    {
        bossCurrentHealth = Mathf.Clamp(bossCurrentHealth - _damage, 0 , startingHealth);
        if(bossCurrentHealth > 0)
        {
            anim.SetTrigger("hurt");

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
    

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
