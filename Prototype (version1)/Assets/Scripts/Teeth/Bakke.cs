using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class Bakke : MonoBehaviour
{
    public TextMeshProUGUI navnTextField;
    public TextMeshProUGUI placeringerTextField;
    public Canvas minCanvas;
    public string level;
    public AudioSource rigtigLydfil;
    public AudioSource metalLydfil;
    public AudioSource forkertLydfil;
    public AudioSource færdigLydfil;

    private static List<string> brugteNavne = new List<string>();

    private bool harTand = false;
    private bool harKorrektTand = false;
    private static int antalKorrektePlaceringer = 0;
    private int antalOpdateringer = 0;
    private GameObject[] maxillaryObjects;
    void Start()
    {
        // Hent alle "Maxillary" tand-objekter og gem dem i et array
        maxillaryObjects = GameObject.FindObjectsOfType<GameObject>()
        .Where(obj => obj.name.StartsWith("Maxillary"))
        .ToArray();

        // Generer et tilfældigt navn fra maxillaryObjects-arrayet,
        // som ikke allerede er blevet brugt
        string nytNavn = "";
        while (nytNavn == "" || brugteNavne.Contains(nytNavn))
        {
            int randomIndex = Random.Range(0, maxillaryObjects.Length);
            nytNavn = maxillaryObjects[randomIndex].name;
        }

        // Tilføj det nye navn til listen over brugte navne
        brugteNavne.Add(nytNavn);

        // Sæt navn til det tilfældige navn fra maxillaryObjects-arrayet
        navnTextField = minCanvas.GetComponentInChildren<TextMeshProUGUI>();
        navnTextField.text = nytNavn;

        // Nulstil tællere
        harTand = false;
        harKorrektTand = false;

    OpdaterPlaceringerTekstfelt();
    }

void OnTriggerStay(Collider other)
{
    if (other.CompareTag("Tooth"))
    {
        metalLydfil.Play();
        Tand tand = other.GetComponent<Tand>();
        if (tand != null && navnTextField != null)
        {
            if (tand.navn == navnTextField.text)
            {
                navnTextField.color = Color.green;
                rigtigLydfil.Play();
                harTand = true;
                if (!harKorrektTand)
                {
                    harKorrektTand = true;
                    antalKorrektePlaceringer++;
                    OpdaterPlaceringerTekstfelt();
                    Debug.Log("Tanden er placeret i den rigtige bakke! Antal korrekte placeringer: " + antalKorrektePlaceringer);
                }
                antalOpdateringer++;
            }
            else
            {
                navnTextField.color = Color.red;
                forkertLydfil.Play();
                harTand = false;
                antalOpdateringer = 0;
                if (harKorrektTand)
                {
                    harKorrektTand = false;
                    antalKorrektePlaceringer--;
                    OpdaterPlaceringerTekstfelt();
                }
                Debug.Log("Tandens navn matcher ikke bakkens navn.");
            }
        }
    }

    // Nulstil harKorrektTand og antalKorrektePlaceringer, hvis tanden har været flyttet væk fra triggeren.
    else if (harTand)
    {
        navnTextField.color = Color.white;
        harTand = false;
        antalOpdateringer = 0;
        if (harKorrektTand)
        {
            harKorrektTand = false;
            OpdaterPlaceringerTekstfelt();
        }
    }

    if (antalKorrektePlaceringer == maxillaryObjects.Length)
    {
        færdigLydfil.Play();

        // Skift til det næste level
        SceneManager.LoadScene(level);

    }
}

    void OpdaterPlaceringerTekstfelt() 
{
    if (placeringerTextField != null) 
    {
        placeringerTextField.text = antalKorrektePlaceringer.ToString();
    }
}
}
