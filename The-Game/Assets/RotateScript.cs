using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * 8f);
    }
}
