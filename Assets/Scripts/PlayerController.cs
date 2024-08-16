using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;
    float rangeLimit = 2.0f;
    float horizontalInput;
    public bool isGameActive = true;
    public Material[] colors;



    void Start()
    {

        int colorIndex = PlayerPrefs.GetInt("Color");
        // Debug.Log("Color " + colorIndex);
        gameObject.GetComponent<Renderer>().material = colors[colorIndex];
        // Debug.Log(isGameActive);

    }

    void Update()
    {
        if (isGameActive) {
            MovePlayer();
        }
        
    }

    private void MovePlayer() {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(horizontalInput * speed * Time.deltaTime, 0, 0);

        if (transform.position.x >= rangeLimit) {
            transform.position = new Vector3(rangeLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -rangeLimit) {
            transform.position = new Vector3(-rangeLimit, transform.position.y, transform.position.z);
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Block")) {
            isGameActive = false;
            // Debug.Log("Game over");
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Block")) {
            isGameActive = false;
            // Debug.Log("Game over");
        }
    }    
}
