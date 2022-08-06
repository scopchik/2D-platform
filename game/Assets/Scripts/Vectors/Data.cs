using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]

public class Data : ScriptableObject
{
    
    public GameObject player;
    public Text coinsTaken;
    public float coinValue;
    public float totalCoins = 0;

    public void Update()
    {
        totalCoins += coinValue;
        coinsTaken.text = "x" + totalCoins;
    }
}
