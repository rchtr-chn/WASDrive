using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME_PauseMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GAME-WIN");
    }
}
