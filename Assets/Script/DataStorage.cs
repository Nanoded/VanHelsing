using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    public int coins = 0;
    public int attackBuff = 1;
    public int healthBuff = 1;

    [SerializeField] Text allCoins;
    [SerializeField] Text collectedCoins;
    [SerializeField] Red_Hood red_Hood;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Coins") == true)
        {
            coins = PlayerPrefs.GetInt("Coins");
            attackBuff = PlayerPrefs.GetInt("AttackBuff");
            healthBuff = PlayerPrefs.GetInt("HealthBuff");
        }
    }


    private void Update()
    {
        allCoins.text = coins.ToString();
        collectedCoins.text = red_Hood.countCoin.ToString();
            
    }


    public void Save()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("AttackBuff", attackBuff);
        PlayerPrefs.SetInt("HealthBuff", healthBuff);
    }
}
