using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoinsFromDrawer : MonoBehaviour {

    public GameObject bip;
    private BipScript bipScript;

    public GameObject drawers;
    private DrawerScript drawersScript;

    public bool[] isCoinTaken;

    public Animator animator;

    // Use this for initialization
    void Start () {
        bipScript = bip.GetComponent<BipScript>();
        drawersScript = drawers.GetComponent<DrawerScript>();

        animator = GetComponent<Animator>();
        for (int i = 0; i < 3; i++)
        {
            isCoinTaken[i] = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (drawersScript.entrance && Input.GetKey("e"))
        {
            if (!drawersScript.playAnima[2] && !isCoinTaken[0])
            {
                bipScript.coins++;
                animator.SetBool("TakeCoin3", true);
                isCoinTaken[0] = true;
            }
            if (!drawersScript.playAnima[6] && !isCoinTaken[1])
            {
                bipScript.coins++;
                animator.SetBool("TakeCoin7", true);
                isCoinTaken[1] = true;
            }
            if (!drawersScript.playAnima[7] && !isCoinTaken[2])
            {
                bipScript.coins++;
                animator.SetBool("TakeCoin8", true);
                isCoinTaken[2] = true;
            }
        }
	}
}
