using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logic_manager : MonoBehaviour
{
    private static logic_manager instance;
    //get the sample object and the sample_script component
    [SerializeField] private GameObject Sample;
    [SerializeField] private GameObject Player;
    private Sample_script sampleScript;

    void Start()
    {
        // Make sure that the object is unique and not destroyed when loading a new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            sampleScript = Sample.GetComponent<Sample_script>();
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
        Player.SetActive(true);
        Sample.SetActive(true);
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
    }

}
