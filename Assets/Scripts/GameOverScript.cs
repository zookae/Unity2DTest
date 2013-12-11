using UnityEngine;
using System.Collections;

/// <summary>
/// start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour {

    void OnGUI() {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        if (
            GUI.Button(
            // centered in X, 1/3 of height in Y
            new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (Screen.height * 1 / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight
                ),
                "Retry!"
            )
            ) {
            // on click load the first level
            // stage1 is name of first level
            Application.LoadLevel("stage1");
        }

        if (
            GUI.Button(
            // centered in X, 2/3 of height in Y
            new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (Screen.height * 2 / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight
                ),
                "Back to menu"
            )
            ) {
            // on click load the menu
            // "menu" is name of the menu
            Application.LoadLevel("menu");
        }
    }
}
