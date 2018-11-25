using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

    public Animator animator;
    public Text stateDoorText;
    public Color theColor;
    public float fadeSpeed = 5f;
    public bool isLocked;
    public bool playAnima;
    public bool entrance;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        stateDoorText.color = Color.clear;
        isLocked = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!isLocked)
            {
                playAnima = true;
                DoorConrtol("open");
            }
            entrance = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" && !isLocked)
        {
            playAnima = false;
            DoorConrtol("open");
        }
        entrance = false;
    }

    private void DoorConrtol(string v)
    {
        animator.SetBool(v, playAnima);
    }

    // Update is called once per frame
    void Update () {
        ColorChange();
	}

    private void ColorChange()
    {
        if (isLocked && entrance)
            stateDoorText.color = Color.Lerp(stateDoorText.color, theColor, fadeSpeed * Time.deltaTime);
        else
            stateDoorText.color = Color.Lerp(stateDoorText.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
