using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BipScript : MonoBehaviour {

    public GameObject timsDoor;
    private DoorScriptWithLight doorScript;

    public Animator animator;
    public bool playAnima;

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text stateText;
    public bool entrance;

    public int coins;

    // Use this for initialization
    void Start () {
        doorScript = timsDoor.GetComponent<DoorScriptWithLight>();
        animator = GetComponentInChildren<Animator>();
        stateText.color = Color.clear;
        coins = 0;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playAnima = true;
            entrance = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playAnima = false;
            entrance = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (entrance)
        {
            if (coins == 5)
            {
                stateText.text = "Here is the key";
                animator.SetBool("TakeKay2", playAnima);
                doorScript.isLocked = false;
            }
            stateText.color = Color.Lerp(stateText.color, theColor, fadeSpeed * Time.deltaTime);
        }
        else
            stateText.color = Color.Lerp(stateText.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
