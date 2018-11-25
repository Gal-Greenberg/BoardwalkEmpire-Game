using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WellScript : MonoBehaviour {

    public GameObject fps;
    private ManagerPlayerScript fpsScript;

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text stateText;
    public bool entrance;

    // Use this for initialization
    void Start () {
        fpsScript = fps.GetComponent<ManagerPlayerScript>();
        stateText.color = Color.clear;
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
                if (fpsScript.health < ManagerPlayerScript.MaxHealth)
                {
                    fpsScript.health = ManagerPlayerScript.MaxHealth;
                    fpsScript.healthText.text = fpsScript.health.ToString() + " / " + ManagerPlayerScript.MaxHealth.ToString();
                }
            }
        }
        else
            stateText.color = Color.Lerp(stateText.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
