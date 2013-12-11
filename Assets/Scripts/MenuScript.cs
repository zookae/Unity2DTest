using UnityEngine;
using System.Collections;

/// <summary>
/// title screen script
/// </summary>
public class MenuScript : MonoBehaviour {

    private GUISkin skin;

    void Start() {
        skin = Resources.Load("GUISkin") as GUISkin;
    }

    void OnGUI() {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        GUI.skin = skin;

        if (
            GUI.Button(
                new Rect(
                    Screen.width/2 - (buttonWidth/2),
                    (Screen.height * 2/3) - (buttonHeight/2),
                    buttonWidth,
                    buttonHeight
                    ),
                    "Start!"
            )
            ) {
            // on click load the first level
            // stage1 is name of first level
            Application.LoadLevel("stage1");
        }
    }
}
