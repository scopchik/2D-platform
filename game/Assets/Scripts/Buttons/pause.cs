using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject button;
    public GameObject hiddenButton;
    public GameObject coin;
    public GameObject health;
    public Behaviour[] components;

    
    public void OnClick()
    {
        button.SetActive(true);
        hiddenButton.SetActive(false);
        coin.SetActive(false);
        health.SetActive(false);
        foreach(Behaviour component in components)
        {
            component.enabled = false;
        }
    }
}
