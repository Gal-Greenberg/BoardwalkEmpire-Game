using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieScript : MonoBehaviour {

    public const int y = 0;
    public const int borders = 44;

    public GameObject zombiePrefab;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 5, 5);
    }

    void Spawn()
    {
        int x = (int)Random.Range(borders, -borders);
        int z = (int)Random.Range(borders, -borders);
        Instantiate(zombiePrefab, new Vector3(x, y, z), Quaternion.identity);
    }
}
