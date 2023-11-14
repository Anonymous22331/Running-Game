using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 spawnPos;
    private float repeatWidth;

    void Start()
    {
        spawnPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < spawnPos.x - repeatWidth)
        {
            transform.position = spawnPos;
        }
    }
}
