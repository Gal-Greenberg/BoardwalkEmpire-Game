using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointScript : MonoBehaviour {

    public Transform[] wayPoint;
    public float speed = 5;
    public int currentWayPoint;
    public Vector3 target, moveDirection;
    private bool flage = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        target = wayPoint[currentWayPoint].position;
        moveDirection = target - transform.position;

        if (moveDirection.magnitude < 1 && flage)
        {
            currentWayPoint = ++currentWayPoint % wayPoint.Length;
            StartCoroutine(Stay());
        }
        GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;
    }

    private IEnumerator Stay()
    {
        flage = false;
        yield return new WaitForSeconds(5);
        flage = true;
    }
}
