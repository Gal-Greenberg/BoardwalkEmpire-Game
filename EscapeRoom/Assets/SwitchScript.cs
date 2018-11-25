using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public GameObject farCamera;
    public GameObject fps;
    public GameObject fpsStartPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //far
        if (Input.GetKey("1"))
        {
            farCamera.SetActive(true);
            fps.SetActive(false);
        }
        //close
        if (Input.GetKey("2"))
        {
            farCamera.SetActive(false);
            fps.SetActive(true);
            fps.transform.position = fpsStartPosition.transform.position;
        }
    }
}
