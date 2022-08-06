using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTaken : MonoBehaviour
{
    [SerializeField] private Text coinsTaken;
    [SerializeField] private int coinValue;
    public int totalCoins = 0;

    void Awake()
    {
        
    }

    public void Start()
    {
        
        if(PlayerPrefs.HasKey("Coins") )
        {
            totalCoins = PlayerPrefs.GetInt("Coins");
            coinsTaken.text = "x" + totalCoins;
            
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            TakeCoins();
            PlayerPrefs.SetInt("Coins", totalCoins);
        }
    }
    public void Update()
    {
        coinsTaken.text = "x" + totalCoins;
    }

    public void TakeCoins()
    {
        totalCoins += coinValue;
    }
}
