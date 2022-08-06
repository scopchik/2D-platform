using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    private float startingHealth;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.startingHealth / 5;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 5;
    }
}
