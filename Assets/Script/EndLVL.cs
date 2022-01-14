using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLVL : MonoBehaviour
{
    [SerializeField] GameObject statistic;
    [SerializeField] GameObject redHood;
    DataStorage dataStorage;

    private void Start()
    {
        dataStorage = redHood.GetComponent<DataStorage>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == redHood.name)
        {
            statistic.SetActive(true);
            redHood.GetComponent<Red_Hood>().enabled = false;
            Time.timeScale = 0;
            dataStorage.Save();
            if (PlayerPrefs.HasKey("LVLCount"))
            {
                if (PlayerPrefs.GetInt("LVLCount") < SceneManager.GetActiveScene().buildIndex)
                    PlayerPrefs.SetInt("LVLCount", SceneManager.GetActiveScene().buildIndex);

            }
            else
            {
                PlayerPrefs.SetInt("LVLCount", SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
