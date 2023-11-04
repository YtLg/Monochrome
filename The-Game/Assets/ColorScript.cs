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
    void Start()
    {
        platformArray = GameObject.FindGameObjectsWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {

        // Player Color Change && Background Color Change
        if (Input.GetKeyDown(KeyCode.Space)){
            if (playerRend.sprite == spriteW){
                playerRend.sprite = spriteB;
                cam.backgroundColor = new Color(255, 255, 255);
                state = 1;
            }
            else{
                playerRend.sprite = spriteW;
                cam.backgroundColor = new Color(0, 0, 0);
                state = 0;
            }
        }

        // Platform Visibility changer
        for (int i = 0; i < platformArray.Length; i++)
        {
            // if background is white
            if (state == 1) {
                Debug.Log("Background is now white");
                // if in the array of platforms, there is one with the color "white"
                
                // get the platforms that are black
                if(platformArray[i].GetComponent<SpriteRenderer>().color == new Color(0, 0, 0)) {
                    // enable them
                    platformArray[i].SetActive(true);
                }
                else
                {
                    // disable the platform
                    Debug.Log("Disabling white platform");
                    platformArray[i].SetActive(false);
                }
            }
            
            else { // if blackground is not white
                Debug.Log("Background is now black");

                if (platformArray[i].GetComponent<SpriteRenderer>().color == new Color(0, 0, 0)) // get the paltforms that are black
                {
                    // disable them
                    platformArray[i].SetActive(false);
                }

                else // get the platforms that are white
                {
                    Debug.Log("Enabling white platform");
                    // enable them
                    platformArray[i].SetActive(true);
                }
            }
        }


    }
}
