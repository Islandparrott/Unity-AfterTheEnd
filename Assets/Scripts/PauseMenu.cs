// Ailand Parriott
// created: 23.03.18
// This script adds functionality to the pause menu
//
// Resources used:
//  6 Minute PAUSE MENU Unity Tutorial
//      https://www.youtube.com/watch?v=9dYDBomQpBQ


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject CanvasPause;
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        CanvasPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseHandler();
        }
    }

    public void PauseHandler()
    {
        isPaused = !isPaused;
        CanvasPause.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    public void GoToMenu()
    {
        PauseHandler();
        SceneManager.LoadScene("MainMenu");
    }
}

