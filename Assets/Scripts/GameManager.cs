using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public GameObject[] spawnObjects;
    public List<GameObject> spawnObjects;
    PlayerController playerController;
    public TextMeshProUGUI gameOverText;
    public AudioSource backgruondMusic;
    // public AudioSource deathSound;
    // int score;
    // GameObject player;
    private bool isGameActive;
    int inputIndex;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        isGameActive = playerController.isGameActive;
        // score = 0;

        InvokeRepeating("RandomObject", 0, 2);
        // StartCoroutine(TimeSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        // RandomObject();
        isGameActive = playerController.isGameActive;
        if (isGameActive == false) {
            GameOver();
        }
        // if (isGameActive == true) {
        //     InvokeRepeating("RandomObject", 0, 2);

        // }
        // StartCoroutine(TimeSpawn());


    }

    IEnumerator TimeSpawn() {
        yield return new WaitForSeconds(1);
        RandomObject();
    }

    private void RandomObject()
    {
        if (isGameActive == true)
        {
            // inputIndex = Random.Range(0, spawnObjects.Length);
            inputIndex = Random.Range(0, spawnObjects.Count);
            Debug.Log("inputIndex: " + inputIndex);

            // Instantiate(spawnObjects[inputIndex], new Vector3(0, 0.5f, 20), spawnObjects[inputIndex].transform.rotation);
            // Kiểm tra xem đối tượng có bị null không
            // if (spawnObjects[inputIndex] != null)
            // {
                Instantiate(spawnObjects[inputIndex], new Vector3(0, 0.5f, 20), spawnObjects[inputIndex].transform.rotation);
            // }
            // else
            // {
            //     Debug.LogWarning("Spawn object is null at index: " + inputIndex);
        }

        // } else {
        //     Debug.Log("Game over " + isGameActive);
        //     GameOver();
        // }
    }

    void GameOver() {
        backgruondMusic.Stop();
        // deathSound.PlayOneShot(deathSound.clip);
        gameOverText.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(0);
        }

    }

}
