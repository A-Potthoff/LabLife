using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logic_manager : MonoBehaviour
{
    public static logic_manager Instance;
    //get the sample object and the sample_script component
    [SerializeField] private GameObject SampleObject;
    [SerializeField] private GameObject PlayerObject;
    [SerializeField] private GameObject InstructorObject;
    private Sample_script sampleScript;
    private Instructor Instructor;
    [SerializeField] private int StepCompleted = 0;
    void Start()
    {
        // Make sure that the object is UNIQUE and not destroyed when loading a new scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            sampleScript = Sample_script.Instance;
            Instructor = Instructor.Instance;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void return_to_lab(bool success = true)
    {
        if (success) // check if the minigame was completed successfully
        {
            StepCompleted++;

            Instructor.gameObject.SetActive(true);
            Instructor.FinishedMinigame();

            StartCoroutine(EndMinigameAfterDelay());

            SceneManager.LoadScene("main");
            Debug.Log("Returned to lab");

            // update the sample script

            switch(StepCompleted){
                case 1:
                    sampleScript.BacteriaLysed();
                    break;
                case 2:
                    sampleScript.isCentrifuged();
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

        }
        else
        {
            SceneManager.LoadScene("main");
            Debug.Log("Returned to lab");
        }
        // also set the player and sample to active
        PlayerObject.SetActive(true);
        SampleObject.SetActive(true);
    }
    
    IEnumerator EndMinigameAfterDelay()
    {
        yield return new WaitForSeconds(2);
        InstructorObject.SetActive(false);
    }


    void Update()
    {
        //when t, r, c is pressed  ---- DEBUGGING PURPOSES
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            sampleScript.Reset();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            return_to_lab();
        }
    }

}
