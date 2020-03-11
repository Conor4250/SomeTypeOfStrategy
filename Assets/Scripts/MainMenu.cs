using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
//I've messed up somewhere either in unity or in the script. It plays all 3 buttons that have been pressed on one button click.
public class MainMenu : MonoBehaviour {
    public bool Start;
    public bool Help;
    public bool Quit;
    public bool StartEditor;
    void Update () {
        if (Input.GetMouseButtonUp (0)) {
            if (Start) {
                SceneManager.LoadScene ("PrototypeScene");
                Debug.Log ("Start clicked");
            }
            if (StartEditor) {
                EditorSceneManager.OpenScene ("Assets/Scenes/PrototypeScene.unity");
                Debug.Log ("Start Editor clicked");
            }
            if (Help) {
                //Coming soon
                Debug.Log ("Help clicked");
            }
            if (Quit) {
                Application.Quit ();
                Debug.Log ("Quit clicked");
            }
        }
    }

}