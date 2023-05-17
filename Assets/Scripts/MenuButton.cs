// Ailand Parriott
// created: 23.03.16
// This script adds functionality to the main menu.
//
// Resources used:
//  Unity Button Tutorial: 
//      https://www.youtube.com/watch?v=Dn8fCuaL-RA


using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButton : MonoBehaviour
{
    public GameObject MenuSettings;
    public GameObject MenuScores;
    public GameObject MenuLogin;

    public TMP_Text usernameDisplay;

    public static bool settingsActive = false;
    public static bool scoreActive = false;
    public static bool loginActive = false;

    void Start()
    {
        MenuSettings.SetActive(false);
        MenuScores.SetActive(false);
        MenuLogin.SetActive(false);

        if (Account.loggedIn)
        {
            usernameDisplay.text = Account.username;
        }
    }

    void Update()
    {

    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // had to separate manageScore and ManageSettings, tried to make it modular,
    // but couldnt get it to appear in the onclick()
    public void ManageScore()
    {
        settingsActive = false;
        
        if (Account.loggedIn)
        {
            scoreActive = !scoreActive;
            MenuScores.SetActive(scoreActive);
        }
        else
        {
            loginActive = !loginActive;
            MenuLogin.SetActive(loginActive);
        }
    }

    public void ManageSettings()
    {
        loginActive = false;

        settingsActive = !settingsActive;
        MenuSettings.SetActive(settingsActive);
    }

    public void QuitApp()
    {
        Application.Quit();

        Debug.Log("Application exited.");
    }




}


