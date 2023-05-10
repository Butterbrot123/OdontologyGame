using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tand : MonoBehaviour
{
    public string navn;                          // Declare a public string variable called "navn"
    private Bakke aktuelBakke = null;            // Declare a private Bakke variable called "aktuelBakke" and set it to null

    void OnTriggerEnter(Collider other)          // This method is called when the game object collides with another collider
    {
        if (other.CompareTag("Bakke"))          // If the other game object has the tag "Bakke"
        {
            aktuelBakke = other.GetComponent<Bakke>();     // Get the Bakke component attached to the other game object and set it to the "aktuelBakke" variable
        }
    }

    void OnTriggerExit(Collider other)           // This method is called when the game object exits the collider of another object
    {
        if (other.CompareTag("Bakke"))          // If the other game object has the tag "Bakke"
        {
            aktuelBakke = null;                 // Set the "aktuelBakke" variable to null
        }
    }

}