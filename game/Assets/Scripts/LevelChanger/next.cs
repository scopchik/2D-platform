using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next : MonoBehaviour
{
    public int levelToLoad;
    public float time;
    public float nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > nextLevel)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        time += Time.deltaTime;
    }
    
}
