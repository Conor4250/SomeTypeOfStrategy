using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    void Update () {

        if (Input.GetKeyUp("1"))
        {
            SceneManager.LoadScene("PrototypeScene");
            Debug.Log("Start clicked");
        } else if (Input.GetKeyUp("2"))
        {
            //Coming soon
            Debug.Log("Help clicked");
        } else if (Input.GetKeyUp("3"))
        {
            Application.Quit();
            Debug.Log("Quit clicked");
        }

    }

}