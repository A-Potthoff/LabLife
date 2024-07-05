using UnityEngine;
using UnityEngine.SceneManagement;

public class PipettingStation : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool isPlayerInContact = false;

    [SerializeField] private GameObject Sample;
    private Sample_script sampleScript;
    private Instructor Instructor;
    private movement_script Player;

    private void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.1f; // Increase scale by 10%

        sampleScript = Sample_script.Instance;
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
                Debug.Log((sampleScript.content == ContentsEnum.Enum.Bacteria));
                Debug.Log((sampleScript.content));

                SceneManager.LoadScene("pipetting_scene_1"); 

                Player.gameObject.SetActive(false);

                Instructor.gameObject.SetActive(true);
                Instructor.IntroPipetting();
            }
            else if (sampleScript.content == ContentsEnum.Enum.CellPellet_DNASupernatant)
            {
                SceneManager.LoadScene("pipetting_scene_2"); 
                Player.gameObject.SetActive(false);
                Instructor.gameObject.SetActive(true);
                Instructor.pipetting2();
            }
            else if (sampleScript.content == ContentsEnum.Enum.PurifiedGene)
            {
                SceneManager.LoadScene("pipetting_scene_3"); 
                Player.gameObject.SetActive(false);
                Instructor.gameObject.SetActive(true);
                Instructor.pipetting3();
            }
            else if (sampleScript.content == ContentsEnum.Enum.Plasmids)
            {
                SceneManager.LoadScene("pipetting_scene_4"); 
                Player.gameObject.SetActive(false);
                Instructor.gameObject.SetActive(true);
                Instructor.pipetting4();
            }
            else if (sampleScript.content == ContentsEnum.Enum.TransformedCells)
            {
                SceneManager.LoadScene("pipetting_scene_5");
                Player.gameObject.SetActive(false);
                Instructor.gameObject.SetActive(true);
                Instructor.pipetting5();
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
