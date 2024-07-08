using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class EndingScript : MonoBehaviour
{
    private Instructor Instructor;
    private static EndingScript Instance;
    [SerializeField] private SpriteRenderer Paper;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private GameObject finalBacteria;
    [SerializeField] private GameObject FeedbackScreen;
    [SerializeField] private TextMeshProUGUI FeedbackText;
    [SerializeField] private Button Button;

    void Awake()
    {
        // Make sure that the object is unique and not destroyed when loading a new scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instructor = Instructor.Instance;
        finalBacteria.SetActive(false);
        Paper.enabled = false;
        TimeText.gameObject.SetActive(false);
        FeedbackScreen.SetActive(false);
        FeedbackText.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        if (TimeText == null)
        {
            Debug.LogError("TimeText is null");
        }
    }

    public void StartOutro()
    {
        StartCoroutine(OutroSequence());
    }

    private IEnumerator OutroSequence()
    {
        finalBacteria.SetActive(true);
        Instructor.gameObject.SetActive(true);
        Instructor.finishedGame();

        //wait for the first speech bubble to disappear
        //yield return new WaitUntil(() => !Instructor.SpeechBubble.isActive && Input.GetKeyDown(KeyCode.Space));
        //yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));

        yield return new WaitForSeconds(1); //give the system time to activate the Instructor

        yield return new WaitUntil(() => !Instructor.SpeechBubble.isActive);

        finalBacteria.SetActive(false);

        yield return new WaitForSeconds(2f);

        FeedbackScreen.SetActive(true);
        TimeText.gameObject.SetActive(true);

        yield return new WaitForSeconds(4.5f);

        FeedbackScreen.SetActive(false);
        TimeText.gameObject.SetActive(false);
        Instructor.gameObject.SetActive(true);
        Instructor.Outro1();
        Paper.enabled = true;

        yield return new WaitUntil(() => !Instructor.SpeechBubble.isActive);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Paper.enabled = false;
        }

        yield return new WaitUntil(() => !Paper.enabled);

        Instructor.gameObject.SetActive(true);
        Instructor.Outro2();

        yield return new WaitUntil(() => !Instructor.SpeechBubble.isActive);

        Destroy(Instructor.gameObject);

        FeedbackScreen.SetActive(true);
        FeedbackText.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);

    }
}
