using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource clickSound; // Reference to the click sound

    public void PlayGame() // Method called when the Play button is pressed
    {
        clickSound.Play(); // Play the click sound
        StartCoroutine(LoadSceneAfterSound("LevelSelector")); // Start coroutine to load the next scene after the click sound has finished playing
    }

    private IEnumerator LoadSceneAfterSound(string sceneToLoad) // Coroutine to load the next scene
    {
        yield return new WaitForSeconds(clickSound.clip.length); // Wait for the click sound to finish playing
        SceneManager.LoadScene(sceneToLoad); // Load the next scene
    }

    public void QuitGame() // Method called when the Quit button is pressed
    {
        clickSound.Play(); // Play the click sound
        StartCoroutine(QuitAfterSound()); // Start coroutine to quit the game after the click sound has finished playing
    }

    private IEnumerator QuitAfterSound() // Coroutine to quit the game
    {
        yield return new WaitForSeconds(clickSound.clip.length); // Wait for the click sound to finish playing
        Application.Quit(); // Quit the game
    }
}
