using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rigidbody gameObject;
    float speed = 5.0f;
    float rangeLimit = 2.0f;
    float horizontalInput;
    // GameManager gameManager;
    public bool isGameActive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        // gameObject = GetComponent<Rigidbody>();
        // gameManager  = gameObject.AddComponent<GameManager>();
        // isGameActive = true;
        // OnGame();
        Debug.Log(isGameActive);

    }

    // Update is called once per frame
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

    // public void OnGame() {
    //     isGameActive = true;
    // }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Block")) {
            isGameActive = false;
            Debug.Log("Game over");
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Block")) {
            isGameActive = false;
            Debug.Log("Game over");
        }
    }    
}
