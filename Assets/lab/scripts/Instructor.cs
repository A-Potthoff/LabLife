using System.Xml.Serialization;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    public static Instructor Instance;
    private string[] lines;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpeechBubble SpeechBubble;

    void Awake()
    {
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

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (SpeechBubble == null) //defined using SerializeField
        {
            Debug.LogError("SPEECHBUBBLE NOT FOUND");
        }
    }

    /*
    public void StartIntroduction()
    {
        lines = new string[9];
        lines[0] = "Hey there!\nI'm Eni and I am happy to welcome you to our lab!\n\n[press 'SPACE' to continue]";
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
        lines = new string[2];
        lines[0] = "Wow! You are doing really good so far.";
        lines[1] = "Now we got a wild mix of DNA and cell parts in the tube. Let's separate them!";

        SpeechBubble.StartDialoge(lines);
    }

    public void IntroCentrifuge()
    {
        lines = new string[4];
        lines[0] = "\nNow we have a wild mix of DNA and cell debrids in the mix. Those have different weights.";
        lines[1] = "\nUsing the centirfuge, we can collect all the heavy stuff at the bottom of our tubes. Our DNA will then be on the top of the tube.";
        lines[2] = "\nBe careful when using the centrifuge. If the centrifuge is not balanced, an imbalance occurs and the centrifuge can be severely damaged.";
        lines[3] = "\nOnce you have balanced the centrifuge, you can start it by pressing 'E'.";

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

    public void CentrifugeSuccess()
    {
        lines = new string[1];
        lines[0] = "Great job! Now we can pipette out the now separated DNA.";

        SpeechBubble.StartDialoge(lines);
    }

    public void IntroPipetting()
    {
        lines = new string[3];
        lines[0] = "\nHere we have our bacteria in the tube. But we want to get the Gene out of them.";
        lines[1] = "\nTherefore we have our special lysing solution that can break the cells open to release the DNA.";
        lines[2] = "\nYou can drag the pipette with your mouse and pipette with SPACE.";

        SpeechBubble.StartDialoge(lines);
    }

    public void NoSampleAtStation()
    {
        lines = new string[1];
        lines[0] = "You need to pick up the sample first!";

        SpeechBubble.StartDialoge(lines);
    }

    public void IncorrectDevice()
    {
        lines = new string[1];
        switch (Random.Range(1, 4))
        {
            case 1:
                lines[0] = "\nSeems like you are some steps ahead!\nThis is not the correct station to proceed.";
                break;
            case 2:
                lines[0] = "\nUnfortunately this is not the next step.\nBut keep your motivation up :)";
                break;
            case 3:
                lines[0] = "\nThis is not the correct station to proceed.";
                break;
        }

        SpeechBubble.StartDialoge(lines);
    }

    public void PipetteTubeWithMixture()
    {
        lines = new string[1];
        lines[0] = "I'm sorry, but you can't separate and pipette the liquids if they are already mixed in the tube.";

        SpeechBubble.StartDialoge(lines);
    }

    public void pipetting2()
    {
        lines = new string[5];
        lines[0] = "\nNow we can carefully get the DNA out of the tube.";
        lines[1] = "\nHowever, we have MUCH MUCH more DNA here than just the gene we want.";
        lines[2] = "\nWe have a certain method to replicate only the gene we want. It is called PCR.";
        lines[3] = "\nWe provided you with a special solution that enables this. With this liquid and the DNA mixed, we can put the tube into a special device (a so called PCR-cycler).";
        lines[4] = "\nThan we will have millions of copies of our gene of interest.";
        SpeechBubble.StartDialoge(lines);
    }

    public void pipetting3()
    {
        lines = new string[4];
        lines[0] = "\nOur gene is now replicated.";
        lines[1] = "\nBut on its own we cannot simply put it into our superhero E. coli. I would simply be broken down.";
        lines[2] = "\nTherefore we incorporate the gene into a so called plasmid. This way it stays active.";
        lines[3] = "\nAlso this plasmid produces a glowing substance. This way we can later easily see if our work payed out :).";

        SpeechBubble.StartDialoge(lines);
    }
    public void pipetting4()
    {
        lines = new string[3];
        lines[0] = "\nAs you see, there is a LOT of pipetting work to do in the lab";
        lines[1] = "\nBut you are doing really good!\nAlso we are really close to our goal now. Only few steps to go!";
        lines[2] = "\nNow we have our plasmids. We simply put them in the same tube with our new bacteria E.coli.";

        SpeechBubble.StartDialoge(lines);
    }

    public void pipetting5()
    {
        lines = new string[4];
        lines[0] = "\nVery last step: put some bacteria from the tube to the Petri Dish!";

        SpeechBubble.StartDialoge(lines);
    }

    public void PipettingIntoFullTube()
    {
        lines = new string[1];
        lines[0] = "The tube is already full. You can't add more liquid to it.";

        SpeechBubble.StartDialoge(lines);
    }

    public void FinishedMinigame()
    {
        lines = new string[1];
        switch (Random.Range(1, 4))
        {
            case 1:
                lines[0] = "\nYou are finished! Nice :)";
                break;
            case 2:
                lines[0] = "\nVery good! :)\nYou`re done.";
                break;
            case 3:
                lines[0] = "\nNice. You are finished";
                break;
        }

        SpeechBubble.StartDialoge(lines);
    }
}

