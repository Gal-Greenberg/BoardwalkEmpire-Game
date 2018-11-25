using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerScript : MonoBehaviour {

    public Animator drawer;
    public bool[] playAnima;

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text[] texts;
    public bool entrance;
    
    // Use this for initialization
    void Start () {
        drawer = GetComponent<Animator>();
        for (int i = 0; i < 9; i++)
        {
            texts[i].color = Color.clear;
            playAnima[i] = false;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            entrance = true;
            SetPlayAnima();
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            entrance = false;
            SetPlayAnima();
            CloseAll();
        }
    }

    private void CloseAll()
    {
        for (int i = 0; i < 9; i++)
        {
            drawer.SetBool((i + 1).ToString(), playAnima[i]);
        }
    }

    private void SetPlayAnima()
    {
        for (int i = 0; i < 9; i++)
        {
            playAnima[i] = entrance;
        }
    }

    private void DrawerConrtol(int i)
    {
        if (Input.GetKey((i + 1).ToString()))
        {
            drawer.SetBool((i + 1).ToString(), playAnima[i]);
            playAnima[i] = (!playAnima[i]);
        }
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < 9; i++)
        {
            if (entrance)
            {
                texts[i].color = Color.Lerp(texts[i].color, theColor, fadeSpeed * Time.deltaTime);
                DrawerConrtol(i);
            }
            else
                texts[i].color = Color.Lerp(texts[i].color, Color.clear, fadeSpeed * Time.deltaTime);
        }
    }
}
