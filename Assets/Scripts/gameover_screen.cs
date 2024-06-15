using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover_screen : MonoBehaviour
{

    public void RestartButton() {
        SceneManager.LoadScene("Level_1");
    }

    public void ExitButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
