using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour {

    public GameObject colliderHat;
    public GameObject timsDoor;
    private HatScript hatScript;
    private DoorScript doorScript;

    public Animator animator;

    public Text stateText;
    public float fadeSpeed = 5f;

    // Use this for initialization
    void Start () {
        hatScript = colliderHat.GetComponent<HatScript>();
        doorScript = timsDoor.GetComponent<DoorScript>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("e") && hatScript.entrance)
        {
            stateText.color = Color.Lerp(stateText.color, Color.clear, fadeSpeed * Time.deltaTime);
            animator.SetBool("TakeKay", true);
            hatScript.isKeyAvailable = false;
            doorScript.isLocked = false;
        }
    }
}
