using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

    public GameObject gun;
    public GameObject fpsGun;

    public bool isGunTaken;

    public Text fpsStateText;

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text stateText;
    public bool entrance;
    
    // Use this for initialization
    void Start () {
        stateText.color = Color.clear;
        isGunTaken = false;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            entrance = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            entrance = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (entrance)
        {
            stateText.color = Color.Lerp(stateText.color, theColor, fadeSpeed * Time.deltaTime);
            if (Input.GetKey("e"))
            {
                isGunTaken = true;
                Destroy(gun);
                fpsGun.SetActive(true);
                fpsStateText.text = "2 - Find the bullets";
            }
        }
        else
            stateText.color = Color.Lerp(stateText.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
