using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public Material[] colors;
    private GameObject playerObject;
    int colorIndex = 0;


    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerObject.GetComponent<Renderer>().sharedMaterial = colors[colorIndex];
    }

    public void SetColor()
    {
        var playerMaterial = playerObject.GetComponent<Renderer>();

        if (colorIndex == 0)
        {
            colorIndex = 1;
            playerMaterial.sharedMaterial = colors[colorIndex];

            // Debug.Log(colorIndex);
        }
        else if (colorIndex == 1)
        {
            colorIndex = 2;
            playerMaterial.sharedMaterial = colors[colorIndex];

            // Debug.Log(colorIndex);
        }
        else
        {
            colorIndex = 0;
            playerMaterial.sharedMaterial = colors[colorIndex];

            // Debug.Log(colorIndex);
        }

    }

    public void StartGame() {
        PlayerPrefs.SetInt("Color", colorIndex);
        SceneManager.LoadScene(1);
    }


}
