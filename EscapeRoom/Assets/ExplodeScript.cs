using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodeScript : MonoBehaviour {

    public GameObject ammo;
    private AmmoScript ammoScript;

    public GameObject doorCity;

    public GameObject remains;

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text stateText;
    public bool entrance;

    // Use this for initialization
    void Start () {
        ammoScript = ammo.GetComponent<AmmoScript>();
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
            if (Input.GetKey("e") && ammoScript.isAmmoTaken)
            {
                Instantiate(remains, remains.transform.position, remains.transform.rotation);
                Destroy(gameObject);
                Animator animator = doorCity.GetComponent<Animator>();
                animator.SetBool("Open", entrance);
            }
        }
        else
            stateText.color = Color.Lerp(stateText.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
