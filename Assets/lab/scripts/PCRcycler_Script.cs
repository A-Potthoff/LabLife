using UnityEngine;
using UnityEngine.SceneManagement;

public class PCRcycler_Script : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool isPlayerInContact = false;
    [SerializeField] private GameObject Sample;
    private Sample_script sampleScript;

    private void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.1f; // Increase scale by 10%

        sampleScript = Sample.GetComponent<Sample_script>();
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
            Start_PCR();
        }
    }

    public void Start_PCR()
    {
        //check if all the necessary conditions are met to start the minigame

        if (sampleScript.content == Sample_script.Content.None)
        {

            Debug.Log("PCR cycler started!");

        }
        else
        {
            Debug.Log("Conditions not met to start the minigame.");
            //call the help (Instructor!)
        }
    }
}
