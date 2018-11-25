using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIScript : MonoBehaviour {

    public float fadeSpeed = 5f;
    public Color theColor;
    public Text stateText;

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementspeed;
    public float damping;

    public Transform fpsTarget;
    Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        stateText.color = Color.clear;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            lockAtPlayer();
            stateText.text = "I can see you"    ;
            stateText.color = Color.Lerp(stateText.color, theColor, fadeSpeed * Time.deltaTime);
        }
        if (fpsTargetDistance < attackDistance)
        {
            attackPlayer();
            stateText.text = "I will kill you";
            stateText.color = Color.Lerp(stateText.color, theColor, fadeSpeed * Time.deltaTime);
        }
        if (fpsTargetDistance > enemyLookDistance)
        {
            stateText.color = Color.clear;
        }
    }

    void lockAtPlayer ()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void attackPlayer ()
    {
        rigidbody.AddForce(transform.forward * enemyMovementspeed);
    }
}
