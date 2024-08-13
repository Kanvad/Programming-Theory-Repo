using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float speed = 3.0f;
    // float rotateSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBlock();
    }

    private void MoveBlock() {
        transform.Translate(0, 0, -speed * Time.deltaTime);
        // transform.Rotate();
        if (transform.position.z < -10) {
            Destroy(gameObject);
        }
    }
}
