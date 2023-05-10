using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour 
{
    // The name of the scene to load
    public string level;

    // This function is called when an object with a collider enters the trigger zone of this object
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger zone has a "Player" tag
        if (other.CompareTag("Player"))
        {
            // Load the scene with the given name
            SceneManager.LoadScene(level);
        }
    }
}
