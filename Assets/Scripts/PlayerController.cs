using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rigidbody gameObject;
    float speed = 5.0f;
    float rangeLimit = 2.0f;
    float horizontalInput;
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        // gameObject = GetComponent<Rigidbody>();
        gameManager  = gameObject.AddComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
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
        if (other.CompareTag("Enemy")) {
            gameManager.isGameActive = false;
        }
    }
}
