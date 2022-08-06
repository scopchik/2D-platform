using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : Health
{
    public int levelToLoad;
    public void PlayerDead()
    {
        SceneManager.LoadScene(levelToLoad);
        
        PlayerPrefs.DeleteKey("Health");
        PlayerPrefs.DeleteKey("Coins");
    }
    
    private void Update()
    {
        if(currentHealth == 0)
        {
            if(currentHealth == 0)
            {
                PlayerDead();
                dead = true;
            }
        }
    }
}
