using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour {

    public Text state;

    public Button menu;
    public Button exit;

    // Use this for initialization
    void Start () {
        state.text = PlayerPrefs.GetString("state");
        Cursor.visible = true;
    }

    public void MenuPress()
    {
        Application.LoadLevel("0");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
