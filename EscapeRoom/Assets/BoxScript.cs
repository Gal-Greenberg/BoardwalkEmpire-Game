using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

    public float effectiveness;
    public float deploymentHeight;

    private bool deployed;

    public GameObject fps;
    private ManagerPlayerCemeteryScript fpsScript;

    public bool entrance;

    // Use this for initialization
    void Start () {
        fpsScript = fps.GetComponent<ManagerPlayerCemeteryScript>();
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
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);

        if (!deployed && Physics.Raycast(landingRay, out hit, deploymentHeight) && hit.collider.tag == "Environment")
        {
            DeployParachute();
        }

        if (entrance && fpsScript.health < ManagerPlayerScript.MaxHealth)
        {
            fpsScript.health = ManagerPlayerScript.MaxHealth;
            fpsScript.healthText.text = fpsScript.health.ToString() + " / " + ManagerPlayerScript.MaxHealth.ToString();
            Destroy(gameObject);
        }
    }

    void DeployParachute()
    {
        deployed = true;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.drag = effectiveness;
    }
}
