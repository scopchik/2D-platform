using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour
{
    [SerializeField] private Health bossHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = bossHealth.bossCurrentHealth / 20;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = bossHealth.bossCurrentHealth / 20;
    }
}
