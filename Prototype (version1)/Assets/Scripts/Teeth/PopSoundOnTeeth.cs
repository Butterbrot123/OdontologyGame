using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopSoundOnTeeth : MonoBehaviour
{
    public AudioSource audioSource; // Reference to an AudioSource component on the GameObject

    void OnTriggerExit(Collider other)
    {
        // Check if the GameObject that exited the trigger is below this GameObject in the y-axis
        if (other.gameObject.transform.position.y < transform.position.y)
        {
            // If it is, play the sound associated with the AudioSource component
            audioSource.Play();
        }
    }
}

