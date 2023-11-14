using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 2);

    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 8);
    }

    void SpawnObject()
    {
        if (!GameObject.FindWithTag("Player").GetComponent<PlayerController>().gameOver)
        {
            int prefabRandomIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[prefabRandomIndex], spawnPos, prefabs[prefabRandomIndex].transform.rotation);
        }
    }
}
