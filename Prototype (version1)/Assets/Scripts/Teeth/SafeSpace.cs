using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpace : MonoBehaviour
{
    private Vector3 startPos; // Declare a private variable to store the starting position of the game object

    void Start()
    {
        startPos = transform.position; // Store the initial position of the game object in the variable
    }

    void Update()
    {
        if (transform.position.y < -2f) // Check if the game object's Y position is less than -2
        {
            transform.position = startPos; // Reset the game object's position to the starting position if it falls below -2
        }
    }
}