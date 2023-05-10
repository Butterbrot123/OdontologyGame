using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public AudioSource SelectSound;

    // This method is called when a level is selected
    public void SelectLevel(string level)
    {
        // Play the sound for selecting a level
        SelectSound.Play();

        // Load the selected level after the sound has finished playing
        StartCoroutine(LoadLevelAfterSound(level));
    }

    // This coroutine loads the selected level after the sound has finished playing
    private IEnumerator LoadLevelAfterSound(string level)
    {
        // Wait for the length of the sound clip
        yield return new WaitForSeconds(SelectSound.clip.length);

        // Load the selected level
        SceneManager.LoadScene(level);
    }
}
