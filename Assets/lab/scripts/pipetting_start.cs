using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object_specific_manager : MonoBehaviour
{

    [SerializeField] private GameObject Sample;
    private Sample_script sampleScript;

    private void Start()
    {
        sampleScript = Sample.GetComponent<Sample_script>();
    }

    public void Start_minigame()
    {
        //check if all the necessary conditions are met to start the minigame

        if (sampleScript.content == Sample_script.Content.None)
        {
            SceneManager.LoadScene("pipetting_scene"); // Replace with your scene name
            Debug.Log("Minigame started!");

            // also set the player and sample to active
            GameObject.Find("Player").SetActive(false);
            GameObject.Find("Sample").SetActive(false);
        }
        else
        {
            Debug.Log("Conditions not met to start the minigame.");
            //call the help (Instructor!)
        }
    }
}

