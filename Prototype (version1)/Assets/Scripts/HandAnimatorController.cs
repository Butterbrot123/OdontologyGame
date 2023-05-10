using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Import Unity Input System library

public class HandAnimatorController : MonoBehaviour
{
    // Reference to the trigger and grip actions defined in the Input System
    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] private InputActionProperty gripAction;

    // Reference to the Animator component attached to this game object
    private Animator anim;

    private void Start() {
        // Get the Animator component of this game object
        anim = GetComponent<Animator>();
    }

    private void Update() {
        // Get the current value of the trigger and grip actions
        float triggerValue = triggerAction.action.ReadValue<float>();
        float gripValue = gripAction.action.ReadValue<float>();

        // Set the values of the "Trigger" and "Grip" parameters in the Animator
        anim.SetFloat("Trigger", triggerValue);
        anim.SetFloat("Grip", gripValue);
    }
}
