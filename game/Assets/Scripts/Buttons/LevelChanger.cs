using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    
    public int levelToLoad;
    public Animator anim;
    public Vector3 position;
    public VectorValue playerStorage;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            playerStorage.initialValue = position;
            //PlayerPrefs.GetFloat("Health", GetComponent<Health>().currentHealth);
        }
    }
    public void Click()
    {
        SceneManager.LoadScene(levelToLoad);
        PlayerPrefs.DeleteKey("Coins");
        PlayerPrefs.DeleteKey("Health");
        playerStorage.initialValue = position;
    }
    public void OnClick()
    {
        SceneManager.LoadScene(levelToLoad);
        playerStorage.initialValue = position;  
    }
    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }

    
}
