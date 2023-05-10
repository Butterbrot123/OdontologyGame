using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System.Collections;


public class ShowName : MonoBehaviour // Define a public class called "ShowName" that inherits from MonoBehaviour.
{
    public TextMeshProUGUI nameText; // Define a public TextMeshProUGUI variable called "nameText".
    public float displayDelay = 0.5f; // Define a public float variable called "displayDelay" and set it to 0.5 seconds.

    private Coroutine displayCoroutine; // Define a private Coroutine variable called "displayCoroutine".

    private void Start() // Define a private method called "Start" that runs once at the start of the script.
    {
        nameText.text = ""; // Set the "nameText" to an empty string.
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>(); // Get the XRBaseInteractable component attached to the object and store it in a variable called "interactable".
        interactable.selectEntered.AddListener((args) => StartDisplayCoroutine(args)); // Add a listener to the "selectEntered" event that calls the "StartDisplayCoroutine" method when an object is selected.
        interactable.selectExited.AddListener((args) => HideName()); // Add a listener to the "selectExited" event that calls the "HideName" method when an object is deselected.
    }

    private void StartDisplayCoroutine(SelectEnterEventArgs args) // Define a private method called "StartDisplayCoroutine" that takes a SelectEnterEventArgs argument.
    {
        if (displayCoroutine != null) // Check if "displayCoroutine" is already running and stop it if it is.
        {
            StopCoroutine(displayCoroutine);
        }
        displayCoroutine = StartCoroutine(DisplayCoroutine()); // Start the "DisplayCoroutine" method and store it in the "displayCoroutine" variable.
    }

    private IEnumerator DisplayCoroutine() // Define a private IEnumerator method called "DisplayCoroutine".
    {
        yield return new WaitForSeconds(displayDelay); // Wait for the number of seconds set in the "displayDelay" variable.
        nameText.text = gameObject.name; // Set the "nameText" to the name of the object that the script is attached to.
        nameText.enabled = true; // Enable the "nameText" so that it is visible.
    }

    private void HideName() // Define a private method called "HideName".
    {
        if (displayCoroutine != null) // Check if "displayCoroutine" is already running and stop it if it is.
        {
            StopCoroutine(displayCoroutine);
        }
        nameText.text = ""; // Set the "nameText" to an empty string.
        nameText.enabled = false; // Disable the "nameText" so that it is hidden.
    }
}