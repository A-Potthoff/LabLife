using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCRcycler_Script : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool isPlayerInContact = false;
    [SerializeField] private GameObject LoadingBar;
    private LoadingBar_Script loadingBarScript;

    private Sample_script sampleScript;
    private movement_script Player;
    private Instructor Instructor;
    private logic_manager LogicManager;

    private void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.1f; // Increase scale by 10%

        loadingBarScript = LoadingBar.GetComponent<LoadingBar_Script>();

        sampleScript = Sample_script.Instance;
        Player = movement_script.Instance;
        Instructor = Instructor.Instance;
        LogicManager = logic_manager.Instance;
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
        if (Player.isCarrying)
        {
            if (sampleScript.content == ContentsEnum.Enum.DNA_PCR_Solution)     // HAS TO BE ADAPTED
            {
                // Starting LoadingBar
                LoadingBar.SetActive(true); // Show the loading bar
                float duration = 7f;
                loadingBarScript.Loading(duration);
                StartCoroutine(finishPCR(duration));
            }
            else if (sampleScript.content == ContentsEnum.Enum.GGA_mix)     // HAS TO BE ADAPTED
            {
                // Starting LoadingBar
                LoadingBar.SetActive(true); // Show the loading bar
                float duration = 7f;
                loadingBarScript.Loading(duration);
                StartCoroutine(finishPCR(duration));
            }
            else if (sampleScript.content == ContentsEnum.Enum.Plasmids_Cells)     // HAS TO BE ADAPTED
            {
                // Starting LoadingBar
                LoadingBar.SetActive(true); // Show the loading bar
                float duration = 7f;
                loadingBarScript.Loading(duration);
                StartCoroutine(finishPCR(duration));
            }
            else
            {
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
    private IEnumerator finishPCR(float duration)
    {
        yield return new WaitForSeconds(duration);
        LogicManager.return_to_lab(true, false);
    }
}
