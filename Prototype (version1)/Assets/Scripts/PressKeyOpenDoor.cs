using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // Importing the Unity XR library
using UnityEngine.SceneManagement;

public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction; // A reference to the instruction object to be shown on the screen
    public GameObject AnimeObject; // A reference to the object to be animated
    public GameObject ThisTrigger; // A reference to the trigger object that will activate the animation
    public AudioSource DoorOpenSound; // A reference to the sound that will play when the door is opened
    private bool Action = false; // A boolean variable to track whether the trigger is active or not
    public string level; // The name of the level to be loaded after the door is opened

    void Start()
    {
        Instruction.SetActive(false); // Hide the instruction object at the start
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true); // Show the instruction object when the player enters the trigger
            Action = true; // Set the Action variable to true to indicate that the trigger is active
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false); // Hide the instruction object when the player leaves the trigger
        Action = false; // Set the Action variable to false to indicate that the trigger is no longer active
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand); // Get the input device (in this case, the right hand controller)
        bool triggerValue;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue) // Check if the trigger button is being pressed
        {
            if (Action == true) // Check if the trigger is active
            {
                Instruction.SetActive(false); // Hide the instruction object
                AnimeObject.GetComponent<Animator>().Play("DoorOpen"); // Play the animation on the AnimeObject
                DoorOpenSound.Play(); // Play the door open sound
                LoadNextScene(); // Load the next scene
                ThisTrigger.SetActive(false); // Deactivate the trigger object
                Action = false; // Set the Action variable to false to indicate that the trigger is no longer active
            }
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(level); // Load the next scene
    }
}

