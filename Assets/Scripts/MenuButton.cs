// Ailand Parriott
// created: 23.03.16
// This script adds functionality to the main menu.
//
// Resources used:
//  Unity Button Tutorial: 
//      https://www.youtube.com/watch?v=Dn8fCuaL-RA


using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();

        Debug.Log("Application exited.");
    }

}


