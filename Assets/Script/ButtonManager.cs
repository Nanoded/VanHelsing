using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button[] selectLVLButtons;

    bool pause;

    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            int count = PlayerPrefs.GetInt("LVLCount");
            for (int i = 0; i < count; i++)
            {
                selectLVLButtons[i].interactable = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            PauseOnOff();
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void StartGameAndNextLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void PauseOnOff()
    {
        if (pause == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if (pause == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void PauseButton()
    {
        pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void SelectLVL(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
