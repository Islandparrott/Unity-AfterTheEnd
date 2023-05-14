// Ailand Parriott
// created: 23.05.13
// updated: 23.05.13
//
// This script adds functionality to account related activits for the Database
// Resources used
//  Unity & MySQL Databases, Part 2: Registering Users
//      https://www.youtube.com/watch?v=4W90-mh70JY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Account : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_InputField inputPassword;

    public Button buttonLogin;
    public Button buttonRegister;

    public static bool loggedIn { get {return username != null;}}
    public static int score;
    public static string username;

    public static void Logout()
    {
        username = null;
    }

    public void LoginAccount()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        // creating HTTP FORM
        WWWForm form = new WWWForm();
        form.AddField("loginOrRegister", "login");
        form.AddField("username", inputName.text);
        form.AddField("password", inputPassword.text);

        // Sending POST request to HTTP with FORM
        UnityWebRequest www = UnityWebRequest.Post(
                "http://localhost/sqlconnect/account.php", form);
        yield return www.SendWebRequest();
        
        username = inputName.text;
// ============================================================================
        // WWW.TEXT IS NOT CORRECT, LOOK INTO HOW ELSE TO DO THIS
        //score = int.Parse(www.text.split('\t')[1]);
        // ALSO NEED TO CHECK IF ACTUALLY LOGGED IN
// ============================================================================

        Debug.Log("User logged in.");

    }

    public void RegisterAccount()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        // creating HTTP FORM
        WWWForm form = new WWWForm();
        form.AddField("loginOrRegister", "register");
        form.AddField("username", inputName.text);
        form.AddField("password", inputPassword.text);

        // Sending POST request to HTTP with FORM
        UnityWebRequest www = UnityWebRequest.Post(
                "http://localhost/sqlconnect/account.php", form);
        yield return www.SendWebRequest();

        Debug.Log("User registered.");

        //if (UnityWebRequest.result == UnityWebRequest.Result.ConnectionError 
        //        || UnityWebRequest.result == 
        //        UnityWebRequest.Result.ProtocolError)
        //{
        //    Debug.Log("User registered.");
        //}
        //else
        //{
        //    Debug.Log("Could not register user. Error #");
        //}
    }
    
}
