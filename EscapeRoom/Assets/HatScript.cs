using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatScript : MonoBehaviour {

    public Animator animator;
    public bool playAnima;

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text stateText;
    public bool entrance;

    public bool isKeyAvailable;

    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        stateText.color = Color.clear;
        isKeyAvailable = true;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            entrance = true;
            playAnima = true;
            HatConrtol("TakeHat");
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" && playAnima)
        {
            entrance = false;
            playAnima = false;
            HatConrtol("TakeHat");
        }
    }

    private void HatConrtol(string v)
    {
        animator.SetBool(v, playAnima);
    }

    // Update is called once per frame
    void Update () {
        ColorChange();
    }

    private void ColorChange()
    {
        if (entrance && isKeyAvailable)
            stateText.color = Color.Lerp(stateText.color, theColor, fadeSpeed * Time.deltaTime);
        else
            stateText.color = Color.Lerp(stateText.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
