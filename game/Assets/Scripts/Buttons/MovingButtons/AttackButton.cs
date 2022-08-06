using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : PlayerAttack
{
    // Update is called once per frame
    public void Click()
    {
        if(cooldownTimer > attackCooldown )
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }
}
