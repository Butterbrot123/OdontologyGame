using UnityEngine;

public class KinematicDisable : MonoBehaviour
{
    private Rigidbody rb; // Reference to the Rigidbody component
    private Vector3 lastPosition; // Store the last position of the object

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the reference to the Rigidbody component attached to the same object
        lastPosition = transform.position; // Initialize lastPosition to the current position of the object
    }

    void FixedUpdate()
    {
        if (transform.position != lastPosition) // Check if the object has moved since last frame
        {
            rb.isKinematic = false; // If the object has moved, disable kinematic to enable physics simulation
        }
        lastPosition = transform.position; // Update lastPosition to the current position of the object
    }
}