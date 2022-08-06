using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject button;
    public GameObject hiddenButton;
    public GameObject coin;
    public GameObject health;
    public Behaviour[] components;
    
    public void OnClick()
    {
        button.SetActive(false);
        hiddenButton.SetActive(true);
        coin.SetActive(true);
        health.SetActive(true);
        foreach(Behaviour component in components)
        {
            component.enabled = true;
        }
    }
}
