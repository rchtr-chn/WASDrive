using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeSceneScript : MonoBehaviour
{
    private GameObject gameOverScreen;
    private GameObject headCanvas;
    private GameObject stageClearScreen;
    private GameObject transmission;
    public GameObject pauseMenu;
    private static bool IsPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        headCanvas = GameObject.Find("Canvas");
        if(headCanvas != null) {
            Transform pauseMenuOBJ = headCanvas.transform.Find("Pause Menu");
            pauseMenu = pauseMenuOBJ.gameObject;

            Transform stageClearOBJ = headCanvas.transform.Find("Stage Clear");
            stageClearScreen = stageClearOBJ.gameObject;

            Transform gameOverOBJ = headCanvas.transform.Find("Game Over");
            gameOverScreen = gameOverOBJ.gameObject;

            Transform transmissionOBJ = headCanvas.transform.Find("Transmission");
            transmission = transmissionOBJ.gameObject;
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
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
        SceneManager.LoadScene("Options");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused=false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused=true;
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
    public void toLevel6()
    {
        SceneManager.LoadScene("Level 6");
    }
    public void toLevel7()
    {
        SceneManager.LoadScene("Level 7");
    }
        public void toLevel8()
    {
        SceneManager.LoadScene("Level 8");
    }
}
