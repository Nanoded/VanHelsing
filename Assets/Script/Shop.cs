using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    int saintBomb;
    int holyAxe;
    int priceBomb = 15;
    int priceKnife = 15;
    [SerializeField] DataStorage dataStorage;
    [SerializeField] Button bombButton;
    [SerializeField] Button axeButton;

    private void Start()
    {
        if(PlayerPrefs.HasKey("SaintBomb") == false)
            PlayerPrefs.SetInt("SaintBomb", 0);

        if (PlayerPrefs.HasKey("HolyAxe") == false)
            PlayerPrefs.SetInt("HolyAxe", 0);


        saintBomb = PlayerPrefs.GetInt("SaintBomb");
        holyAxe = PlayerPrefs.GetInt("HolyAxe");
    }


    // Update is called once per frame
    void Update()
    {
            if (dataStorage.coins < priceBomb || saintBomb == 1)
                bombButton.interactable = false;
            else
                bombButton.interactable = true;

            if (dataStorage.coins < priceKnife || holyAxe == 1)
                axeButton.interactable = false;
            else
                axeButton.interactable = true;
    }

    public void BuyBomb()
    {
        PlayerPrefs.SetInt("SaintBomb", 1);
        PlayerPrefs.SetInt("Coins", dataStorage.coins - 15);
        saintBomb = PlayerPrefs.GetInt("SaintBomb");
    }

    public void BuyAxe()
    {
        PlayerPrefs.SetInt("HolyAxe", 1);
        PlayerPrefs.SetInt("AttackBuff", 2);
        PlayerPrefs.SetInt("Coins", dataStorage.coins - 15);
        holyAxe = PlayerPrefs.GetInt("HolyAxe");
    }
}
