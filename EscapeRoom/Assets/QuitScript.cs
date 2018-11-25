using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour {

    public int level;

    // Use this for initialization
    void Start () {
        level = Application.loadedLevel;
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetString("state", "Win");
        Application.LoadLevel(level + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            PlayerPrefs.SetString("state", "Game Over");
            Application.LoadLevel(4);
        }
    }
}
