using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    public SpriteRenderer playerRend;
    public Sprite spriteW;
    public Sprite spriteB;
    public Camera cam;
    private int state = 1;  // 1 = black platforms only , 0 = white platforms only
    // Start is called before the first frame update
    private GameObject[] platformArray;
    private GameObject[] hazardArray;
    private GameObject[] enemyArray;

    public Sprite enemyB;
    void Start()
    {
        platformArray = GameObject.FindGameObjectsWithTag("Platform");
        hazardArray = GameObject.FindGameObjectsWithTag("Hazard");
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {

        // Player Color Change && Background Color Change
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (playerRend.sprite == spriteW) {
                playerRend.sprite = spriteB;
                cam.backgroundColor = new Color(255, 255, 255);
                state = 1;
            }
            else {
                playerRend.sprite = spriteW;
                cam.backgroundColor = new Color(0, 0, 0);
                state = 0;
            }
        }

        //SPAGHETTI 

        // Platform Visibility changer
        for (int i = 0; i < platformArray.Length; i++)
        {
            // if background is white
            if (state == 1) {
                // get the platforms that are black
                if (platformArray[i].GetComponent<SpriteRenderer>().color == new Color(0, 0, 0))
                {
                    // enable them
                    platformArray[i].SetActive(true);
                }

                else
                {
                    // disable the platform
                    platformArray[i].SetActive(false);
                }
            }
            // if blackground is not white
            else {
                if (platformArray[i].GetComponent<SpriteRenderer>().color == new Color(0, 0, 0)) { // get the paltforms that are black

                    // disable them
                    platformArray[i].SetActive(false);
                }
                // get the platforms that are white
                else {
                    // enable them
                    platformArray[i].SetActive(true);
                }
            }
        }


        //Changes visibility of spikes.
        for (int j = 0; j < hazardArray.Length; j++){
            if (state == 1)
            {
                if (hazardArray[j].GetComponent<SpriteRenderer>().color == new Color(0, 0, 0))
                {
                    hazardArray[j].SetActive(true);
                }
                else
                {
                    hazardArray[j].SetActive(false);
                }
            }
            else
            {
                if (hazardArray[j].GetComponent<SpriteRenderer>().color == new Color(0, 0, 0)) {
                    hazardArray[j].SetActive(false);
                        }
                else
                {
                    hazardArray[j].SetActive(true);
                }
            }
        }

        //Changes visibility of the enemies.
        for (int k = 0; k < enemyArray.Length; k++)
        {
            if (state == 1)
            {
                if(enemyArray[k].GetComponent<SpriteRenderer>().sprite == enemyB)
                {
                    enemyArray[k].SetActive(true);
                }
                else
                {
                    enemyArray[k].SetActive(false);
                }
            }

            else
            {
                if (enemyArray[k].GetComponent<SpriteRenderer>().sprite == enemyB)
                {
                    enemyArray[k].SetActive(false);
                }
                else
                {
                    enemyArray[k].SetActive(true);
                }
            }
        }

    }
}
