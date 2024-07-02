using UnityEngine;
using UnityEngine.SceneManagement;

public class Easteregg : MonoBehaviour
{
    private bool isPlayerInContact = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInContact = true;
            Start_minigame();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInContact = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Object clicked");
        if (isPlayerInContact)
        {
            Start_minigame();
        }
    }

    public void Start_minigame()
    {
        //check if all the necessary conditions are met to start the minigame

        SceneManager.LoadScene("easteregg"); // Replace with your scene name
        Debug.Log("Easteregg started!");

        // also set the player and sample to active
        GameObject.Find("Sample").SetActive(false);
    }
}

