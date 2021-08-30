using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public static UIController uiController;
    public GameObject[] canvas;
    public LevelLoader gameLevelLoader;
    bool isPaused = false;
    

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canvas[0].activeSelf == false && isPaused == false)
        {
            OpenGameMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && canvas[0].activeSelf == true && isPaused == true)
        {
            CloseGameMenu();
        }

        if (canvas[0].activeSelf == true && isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
            print(Time.timeScale);
        }

    }
    public void OpenGameMenu()
    {
        canvas[0].SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        print(Time.timeScale);
    }
    public void CloseGameMenu()
    {
        canvas[0].SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        print(Time.timeScale);
    }

    public void CloseOptionsTab()
    {
        canvas[0].GetComponentInChildren<Button>().enabled = true;
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
    }

    public void OpenAudioTab()
    {
        canvas[4].SetActive(true);
        canvas[0].GetComponentInChildren<Button>().enabled = false;
    }
    public void OpenControlsTab()
    {
        canvas[6].SetActive(true);
        canvas[0].GetComponentInChildren<Button>().enabled = false;
    }
    public void OpenGraphicsTab()
    {
        canvas[5].SetActive(true);
        canvas[0].GetComponentInChildren<Button>().enabled = false;
    }
      
    public void YesQuitGame()
    {
        Application.Quit();
        print("Game Shutting Down");
    }

    public void NoQuitGame()
    {
        canvas[1].SetActive(false);
        canvas[0].GetComponentInChildren<Button>().enabled = true;
    }
    public void QuitGame()
    {
        canvas[1].SetActive(true);
        canvas[0].GetComponentInChildren<Button>().enabled = false;
    }

    public void BackToMainMenu()
    {
        canvas[2].SetActive(true);
        canvas[0].GetComponentInChildren<Button>().enabled = false;
    }

    public void YesBackToMainMenu()
    {
        canvas[0].SetActive(false);
        canvas[3].SetActive(true);
        StartCoroutine(gameLevelLoader.LoadMainMenuScene());
    }
    public void NoBackToMainMenu()
    {
        canvas[0].GetComponentInChildren<Button>().enabled = true;
        canvas[2].SetActive(false);
    }
}

