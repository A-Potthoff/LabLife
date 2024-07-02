using UnityEngine;

public class Instructor : MonoBehaviour
{
    public static Instructor Instance;
    private string[] lines;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpeechBubble SpeechBubble;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            //SpeechBubble = GameObject.Find("SpeechBubble").GetComponent<SpeechBubble>(); //hopefully redundant now?!?!
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (SpeechBubble == null)
            {
                Debug.LogError("SPEECHBUBBLE NOT FOUND");
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void StartIntroduction()
    {
        lines = new string[7];
        lines[0] = "Hey there!\nWelcome to our lab!\n\n(press 'SPACE' to continue)";
        lines[1] = "We are incredibly happy you decided to pursue your PhD here!\nWe also already have the first important task for you!";
        lines[2] = "Not long ago researchers found a new plastic degrading bacterium inside the ocean!";
        lines[3] = "However, they grow really really slow, which makes it practically impossible to use them in the lab...";
        lines[4] = "Therefore we wanna take the gene that is responsible for this degradation out of the bactierum ...";
        lines[5] = "...and set it into E.coli. E.coli are fast growing bacteria we know well and are easy to handle.";
        lines[6] = "This way we can produce the enzyme in large quantities and hopefully use it to degrade plastic!";

        Debug.Log("Instructor started");

        SpeechBubble.StartDialoge(lines);
    }
    
    /*
    public void StartIntroduction()
    {
        lines = new string[1];
        lines[0] = "Hey there!\nbla bla";

        Debug.Log("Instructor started");

        SpeechBubble.StartDialoge(lines);
    }
    */

    public void IntroCentrifuge()
    {
        lines = new string[4];
        lines[0] = "This is the centrifuge. It is used to separate the different components of a liquid by spinning it at high speed.";
        lines[1] = "The heavier components (like cell debrid) are pushed to the bottom of the tube, while the lighter components (DNA) stay on top.";
        lines[2] = "Be careful when using it. If the centrifuge is not balanced, an imbalance occurs and the centrifuge breaks down.";
        lines[3] = "Once you have balanced the centrifuge, you can start it by pressing 'E'.";

        Debug.Log("Instructor started");

        SpeechBubble.StartDialoge(lines);
    }

    public void FailCentrifuge()
    {
        lines = new string[2];
        lines[0] = "BE CAREFUL! You have to balance the centrifuge first before starting it.";
        lines[1] = "Lab equipment can be extremely expensive so we dont want to break it!";

        Debug.Log("Instructor started");

        SpeechBubble.StartDialoge(lines);
    }
}

