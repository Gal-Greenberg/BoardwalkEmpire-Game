using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCityScript : MonoBehaviour {

    public Animator animator;
    public bool playAnima;
    public bool entrance;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playAnima = true;
            DoorConrtol("Open");
            entrance = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playAnima = false;
            DoorConrtol("Open");
            entrance = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void DoorConrtol(string v)
    {
        animator.SetBool(v, playAnima);
    }
}
