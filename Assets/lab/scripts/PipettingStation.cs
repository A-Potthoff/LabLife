using UnityEngine;
using UnityEngine.SceneManagement;

public class PipettingStation : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool isPlayerInContact = false;
    private bool alreadyInstructed = false;

    [SerializeField] private GameObject Sample;
    private Sample_script sampleScript;
    private Instructor Instructor;
    private movement_script Player;

    private void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.1f; // Increase scale by 10%

        sampleScript = Sample.GetComponent<Sample_script>();
        Instructor = Instructor.Instance;
        Player = movement_script.Instance;
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
        Debug.Log("Object clicked");
        if (isPlayerInContact)
        {
            Start_minigame();
        }
    }

    public void Start_minigame()
    {
        if (Player.isCarrying)//check if all the necessary conditions are met to start the minigame
        {
            if (sampleScript.content == ContentsEnum.Enum.Bacteria)
            {
                SceneManager.LoadScene("pipetting_scene"); // Replace with your scene name
                Debug.Log("Pipetting started!");

                // also set the player and sample to active
                GameObject.Find("Player").SetActive(false);

                if (!alreadyInstructed)
                {
                    alreadyInstructed = true;
                    Instructor.gameObject.SetActive(true);
                    Instructor.IntroPipetting();
                }
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
