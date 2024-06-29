using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class logic_manager : MonoBehaviour
{
    private static logic_manager instance;
    //get the sample object and the sample_script component
    [SerializeField] private GameObject Sample;
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

    //when t is pressed, call the step_transfer_bacteria function  ---- DEBUGGING PURPOSES
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            step_transfer_bacteria();
        }
    }

}
