using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Play : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("Level1");
    }
}
