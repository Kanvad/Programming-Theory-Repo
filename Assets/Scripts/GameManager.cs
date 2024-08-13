using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnObjetcs;
    GameObject player;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        // Debug.Log(spawnObjetcs.Length);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RandomObject()
    {
        if (isGameActive == true)
        {
            int inputIndex = Random.Range(0, spawnObjetcs.Length - 1);

            Instantiate(spawnObjetcs[inputIndex], new Vector3(0, 0.5f, 20), spawnObjetcs[inputIndex].transform.rotation);
        }
    }
    
}
