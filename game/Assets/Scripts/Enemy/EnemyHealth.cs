using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public void EnemyTakeDamage(float _damage)
    {
        enemyCurrentHealth = Mathf.Clamp(enemyCurrentHealth - _damage, 0 , enemyStartingHealth);
        if(enemyCurrentHealth > 0)
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
}
