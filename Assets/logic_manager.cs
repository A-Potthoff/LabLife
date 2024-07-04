using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logic_manager : MonoBehaviour
{
    private static logic_manager instance;
    //get the sample object and the sample_script component
    [SerializeField] private GameObject SampleObject;
    [SerializeField] private GameObject PlayerObject;
    [SerializeField] private GameObject InstructorObject;
    private Sample_script sampleScript;
    private Instructor Instructor;

    void Start()
    {
        // Make sure that the object is UNIQUE and not destroyed when loading a new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            sampleScript = SampleObject.GetComponent<Sample_script>();
            Instructor = Instructor.Instance;

            // instead of starting the instructor here (prior versions), it will be started once the player destroys the disclaimer
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void step_transfer_bacteria()
    {
        // call the bacteria_transferred function from the sample script
        sampleScript.bacteria_transferred();
    }

    public void return_to_lab(bool success = true)
    {
        // check if the minigame was completed successfully
        if (success)
        {
            SceneManager.LoadScene("main"); // Replace with your scene name
            Debug.Log("Returned to lab");
        }
        else
        {
            // do something different
        }
        // also set the player and sample to active
        PlayerObject.SetActive(true);
        SampleObject.SetActive(true);
    }
    
    void Update()
    {
        //when t, r, c is pressed  ---- DEBUGGING PURPOSES
        if (Input.GetKeyDown(KeyCode.T))
        {
            step_transfer_bacteria();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            sampleScript.Reset();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            return_to_lab();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            InstructorObject.SetActive(true);
            Instructor.StartIntroduction();
        }
    }

}
