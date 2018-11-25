using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxScript : MonoBehaviour {

    public const int y = 10;
    public const int borders = 44;

    public GameObject boxPrefab;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 5, 50);
    }

    void Spawn()
    {
        int x = (int)Random.Range(borders, -borders);
        int z = (int)Random.Range(borders, -borders);
        Instantiate(boxPrefab, new Vector3(x, y, z), Quaternion.identity);
    }
}
