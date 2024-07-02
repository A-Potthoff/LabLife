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

    /*
    public void StartIntroduction()
    {
        lines = new string[9];
        lines[0] = "Hey there!\nWelcome to our lab!\n\n[press 'SPACE' to continue]";
        lines[1] = "We are incredibly happy you decided to pursue your Master here!\nWe also already have the first important task for you!";
        lines[2] = "Not long ago researchers found a new plastic degrading bacterium inside the ocean!";
        lines[3] = "However, they grow really really slow, which makes it difficult to work them in the lab.";
        lines[4] = "Therefore we wanna take the gene that is responsible for this degradation out of the bactierum ...";
        lines[5] = "...and set it into E.coli. E.coli are fast growing bacteria, so working with them is easy. Also they are well studied already, which a big benefit for us.";
        lines[6] = "This way we can let the bacteria produce the enzyme in large amounts and hopefully use it to break down plastic!";
        lines[7] = "So let's get started!";
        lines[8] = "You can pick up the sample by pressing 'E' when you are close to it.";

        SpeechBubble.StartDialoge(lines);
    }
    */

    //*/
    public void StartIntroduction()
    {
        lines = new string[1];
        lines[0] = "Hey there!\nbla bla";

        SpeechBubble.StartDialoge(lines);
    }
    //*

    public void SamplePickedUp()
    {
        lines = new string[1];
        lines[0] = "Great! Now you can start with the first step of the experiment.";
        lines[1] = "To interact with the lab equipment simply walk up to it click on them.";

        SpeechBubble.StartDialoge(lines);
    }

    public void IntroPipettingStation()
    {
        lines = new string[4];
        lines[0] = "First, we need to get the DNA out of the cells.";
        lines[1] = "We have a special liquid that can break up the cells. Doing this will free the DNA";
        lines[2] = "Take the pipette and transfer both your cells and the special liquid into the new tube.";
        lines[3] = "You can move the pipette using the mouse and take up and release liquid using [SPACE].";

        SpeechBubble.StartDialoge(lines);
    }

    public void FirstPipettingSuccess()
    {
        lines = new string[1];
        lines[0] = "Wow! You are doing really good so far.";
        lines[1] = "Now we got a wild mix of DNA and cell parts in the tube. Let's separate them!";

        SpeechBubble.StartDialoge(lines);
    }

    public void IntroCentrifuge()
    {
        lines = new string[4];
        lines[0] = "Using the centirfuge, we can collect all the heavy stuff at the bottom of our tubes.";
        lines[1] = "DNA and the cell debrids have different weights, so we can isolate our genes here :).";
        lines[2] = "Be careful when using the centrifuge. If the centrifuge is not balanced, an imbalance occurs and the centrifuge can be severely damaged.";
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

    public void Test()
    {
        lines = new string[1];
        lines[0] = "This is a test";

        Debug.Log("Instructor started");

        SpeechBubble.StartDialoge(lines);
    }
}

