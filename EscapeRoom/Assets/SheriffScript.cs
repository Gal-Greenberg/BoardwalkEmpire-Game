using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheriffScript : MonoBehaviour {

    private NavMeshAgent agent;
    public float enemyDistanceRun;

    public GameObject player;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (transform.position.x > 42 || transform.position.z > 42 || transform.position.x < -42 || transform.position.z < -42)
        {
            Debug.Log("sssssssssssssss");
            transform.rotation = transform.rotation * Quaternion.Euler(0, 70, 0);
            Vector3 delta = new Vector3(10, 0, 10);
            agent.SetDestination(transform.position + delta);
        }

        if (distance < enemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            //if (newPos.x == 42 || newPos.z == 42 || newPos.x == -42 || newPos.z == -42)
            //{
            //    Debug.Log("sssssssssssssss");
            //    transform.rotation = transform.rotation * Quaternion.Euler(0, 90, 0);
            //}

            agent.SetDestination(newPos);
        }
	}
}
