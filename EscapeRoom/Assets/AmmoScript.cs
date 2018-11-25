using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour {

    public GameObject ammo;
    public bool isAmmoTaken;

    public GameObject gun;
    private GunScript gunScript;

    public Text fpsStateText;

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text stateText;
    public bool entrance;

    // Use this for initialization
    void Start () {
        gunScript = gun.GetComponent<GunScript>();
        stateText.color = Color.clear;
        isAmmoTaken = false;
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
            if (Input.GetKey("e") && gunScript.isGunTaken)
            {
                isAmmoTaken = true;
                Destroy(ammo);
                fpsStateText.text = "3 - Find the diamonds";
            }
        }
        else
            stateText.color = Color.Lerp(stateText.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
