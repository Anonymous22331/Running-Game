using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if (!GameObject.FindWithTag("Player").GetComponent<PlayerController>().gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < -5 && this.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
