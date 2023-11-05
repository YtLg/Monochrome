using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    // sorting by index instead of name in case we change name later, safer.
    public int sceneBuildIndex;


    // when something hits the goal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // just in case something else hits it so it doesn't complete level otherwise.
        if (collision.gameObject.CompareTag("Player"))
        {
            // load the next level
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }

    }
}
