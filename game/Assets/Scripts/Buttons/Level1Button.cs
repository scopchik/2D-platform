using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Level1Button : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("Level1");
    }
}
