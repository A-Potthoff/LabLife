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
    private Sample_script Sample;
    private Instructor Instructor;
    void Start()
    {
        // Make sure that the object is UNIQUE and not destroyed when loading a new scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            Sample = Sample_script.Instance;
            Instructor = Instructor.Instance;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void return_to_lab(bool success = true, bool LoadSceneNecessary = true)
    {
        
        if (success) // check if the minigame was completed successfully
        {
            if (LoadSceneNecessary)
            {
                Instructor.gameObject.SetActive(true);
                Instructor.FinishedMinigame();

                StartCoroutine(EndMinigameAfterDelay());
            }

            StartCoroutine(UpdateSampleAndDoInstructor());
        }
        else
        {
            SceneManager.LoadScene("main");
            Debug.Log("Returned to lab");

            PlayerObject.SetActive(true);
            SampleObject.SetActive(true);
        }
    }
    
    IEnumerator EndMinigameAfterDelay()
    {
        yield return new WaitForSeconds(2);
        InstructorObject.SetActive(false);

        SceneManager.LoadScene("main");

        // set the player and sample to active
        PlayerObject.SetActive(true);
        SampleObject.SetActive(true);
    }

    IEnumerator UpdateSampleAndDoInstructor()
    {
        yield return new WaitForSeconds(2.1f);

        // update the sample script

        switch (Sample.content)
        {
            case ContentsEnum.Enum.Bacteria:
                Sample.LysedBacteria();
                Instructor.gameObject.SetActive(true);
                Instructor.FirstPipettingSuccess();
                break;
            case ContentsEnum.Enum.LysedBacteria:
                Sample.isCentrifuged();
                Instructor.gameObject.SetActive(true);
                Instructor.CentrifugeSuccess();
                break;
            case ContentsEnum.Enum.CellPellet_DNASupernatant:
                Sample.DNA_PCR_Solution();

                break;
            case ContentsEnum.Enum.DNA_PCR_Solution:
                Sample.PurifiedGene();
                break;
            case ContentsEnum.Enum.PurifiedGene:
                Sample.GGA_mix();
                break;
            case ContentsEnum.Enum.GGA_mix:
                Sample.Plasmids();
                break;
            case ContentsEnum.Enum.Plasmids:
                Sample.Plasmids_Cells();
                break;
            case ContentsEnum.Enum.Plasmids_Cells:
                Sample.TransformedCells();
                break;
            case ContentsEnum.Enum.TransformedCells:
                Sample.PetriDish();
                break;
            case ContentsEnum.Enum.PetriDish:
                // end of the game
                break;
        }
    }

    void Update()
    {
        //when t, r, c is pressed  ---- DEBUGGING PURPOSES
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Sample.Reset();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            return_to_lab();
        }
    }

}
