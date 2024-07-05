using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeSceneScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject headCanvas;
    public GameObject stageClearScreen;
    public GameObject transmission;
    public GameObject settings;
    public GameObject pauseMenu;

    void Start()
    {
        Time.timeScale = 1f;
        headCanvas = GameObject.Find("Canvas");
        if(headCanvas != null) {
            Transform pauseMenuOBJ = headCanvas.transform.Find("Pause Menu");
            pauseMenu = pauseMenuOBJ.gameObject;
            headCanvas = GameObject.Find("Canvas");

            Transform stageClearOBJ = headCanvas.transform.Find("Stage Clear");
            stageClearScreen = stageClearOBJ.gameObject;
            headCanvas = GameObject.Find("Canvas");

            Transform gameOverOBJ = headCanvas.transform.Find("Game Over");
            gameOverScreen = gameOverOBJ.gameObject;
            headCanvas = GameObject.Find("Canvas");

            Transform transmissionOBJ = headCanvas.transform.Find("Transmission");
            transmission = transmissionOBJ.gameObject;
            headCanvas = GameObject.Find("Canvas");

            Transform settingsOBJ = headCanvas.transform.Find("optionsmenu");
            settings = settingsOBJ.gameObject;
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(pauseMenu.activeInHierarchy == false) {
                Pause();
            }
            else {
                Resume();
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab)) {
            if(settings.activeInHierarchy == false) {
                ToSettings();
            }
            else {
                Resume();
            }
        }
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        transmission.SetActive(false);
    }

    public void stageClear()
    {
        stageClearScreen.SetActive(true);
        transmission.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ToSettings() {
        Debug.Log("settings!");
            settings.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 0f;
    }

    public void Resume()
    {
        Debug.Log("resumed!");
            pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        if(settings.activeInHierarchy == true) {
                settings.SetActive(false);
        }
    }

    public void Pause()
    {
            pauseMenu.SetActive(true);
            settings.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ToMainMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void toLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void toLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void toLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void toLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void toLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }
}

