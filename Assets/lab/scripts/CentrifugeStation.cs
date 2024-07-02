using UnityEngine;
using UnityEngine.SceneManagement;

public class CentrifugeStation : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool isPlayerInContact = false;

    private Sample_script sampleScript;
    private movement_script Player ;
    private Instructor Instructor;

    private void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.1f; // Increase scale by 10%

        sampleScript = Sample_script.Instance;
        Player = movement_script.Instance;
        Instructor = Instructor.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.localScale = enlargedScale;
            isPlayerInContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.localScale = originalScale;
            isPlayerInContact = false;
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("Object clicked");
        if (isPlayerInContact)
        {
            Start_minigame();
        }
    }

    public void Start_minigame()
    {
        //check if all the necessary conditions are met to start the minigame
        if (Player.isCarrying) 
        {
            if (sampleScript.content == Sample_script.Content.cells)
            {
                SceneManager.LoadScene("centrifugation_scene"); // Replace with your scene name
                Debug.Log("Centrifugation started!");

                // also set the player and sample to active
                Player.gameObject.SetActive(false); //sample does not have to be set inactive because it is held by player
            }
            else
            {
                Debug.Log("Conditions not met to start the minigame.");
                Instructor.gameObject.SetActive(true);
                Instructor.IncorrectDevice();
            }
        }
        else
        {
            Instructor.gameObject.SetActive(true);
            Instructor.NoSampleAtStation();
        }

        
    }
}
