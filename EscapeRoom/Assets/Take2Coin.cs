using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Take2Coin : MonoBehaviour {

    public GameObject bip;
    private BipScript bipScript;

    public Animator animator;
    public bool playAnima;

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text stateText;
    public bool entrance;

    public bool isCoinTaken;

    // Use this for initialization
    void Start () {
		bipScript = bip.GetComponent<BipScript>();
        animator = GetComponent<Animator>();
        stateText.color = Color.clear;
        isCoinTaken = false;
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
            stateText.color = Color.Lerp(stateText.color, theColor, fadeSpeed * Time.deltaTime);
            if (Input.GetKey("e") && !isCoinTaken)
            {
                bipScript.coins += 2;
                animator.SetBool("Take2Coin", playAnima);
                isCoinTaken = true;
            }
        }
        else
            stateText.color = Color.Lerp(stateText.color, Color.clear, fadeSpeed * Time.deltaTime);

    }
}
