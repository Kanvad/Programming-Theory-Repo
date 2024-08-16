using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnObjects;
    Vector3 spawnPos = new Vector3(0, 0.5f, 20);
    PlayerController playerController;
    public TextMeshProUGUI gameOverText;
    public AudioSource backgruondMusic;
    private bool isGameActive;
    float timeRate = 2.0f;
    float time0 = 0;
    float timeSpawn = 1;
    int inputIndex;


    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        isGameActive = playerController.isGameActive;

        InvokeRepeating("RandomObject", time0, timeRate);
    }

    void Update()
    {
        isGameActive = playerController.isGameActive;
        if (isGameActive == false)
        {
            GameOver();
        }

    }

    IEnumerator TimeSpawn()
    {
        yield return new WaitForSeconds(timeSpawn);
        RandomObject();
    }

    private void RandomObject()
    {
        if (isGameActive == true)
        {
            inputIndex = Random.Range(0, spawnObjects.Count);
            // Debug.Log("inputIndex: " + inputIndex);

            Instantiate(spawnObjects[inputIndex], spawnPos, spawnObjects[inputIndex].transform.rotation);
        }
    }

    void GameOver()
    {
        backgruondMusic.Stop();
        PlayerPrefs.DeleteAll();

        gameOverText.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }

    }

}
