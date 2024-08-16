using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float speed = 5.0f;


    void Update()
    {
        MoveBlock();
    }

    private void MoveBlock()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
        if (transform.position.z < -10)
        {
            Destroy(gameObject);

        }
    }
}
