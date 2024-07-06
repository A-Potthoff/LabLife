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

    public void StartIntroduction()
    {
        lines = new string[9];
        lines[0] = "Hey there!\nI'm Eni and I am happy to welcome you to our lab!\n[press 'SPACE' to continue]";
        lines[1] = "We are incredibly happy you decided to pursue your Master here!\nWe also already have the first important task for you!";
        lines[2] = "\nNot long ago researchers found a new plastic degrading bacterium inside the ocean!";
        lines[3] = "\nHowever, they grow really really slow, which makes it difficult to work them in the lab.";
        lines[4] = "\nTherefore we wanna take the gene that is responsible for this degradation out of the bactierum ...";
        lines[5] = "...and set it into E.coli. E.coli are fast growing bacteria, so working with them is easy. Also they are well studied already, which is a big benefit for us.";
        lines[6] = "This way we can let the bacteria produce the enzyme in large amounts and hopefully use it to break down plastic!";
        lines[7] = "\nSo let's get started!";
        lines[8] = "\nYou can pick up the sample by pressing 'E' when you are close to it.";

        SpeechBubble.StartDialoge(lines);
    }

    /*
    public void StartIntroduction()
    {
        lines = new string[1];
        lines[0] = "Hey there!\nbla bla";

        SpeechBubble.StartDialoge(lines);
    }
    */

    public void NoSampleAtStation()
    {
        lines = new string[1];
        lines[0] = "\nYou need to pick up the sample first!";

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

    public void SamplePickedUp()
    {
        lines = new string[1];
        lines[0] = "\nGreat! Now you can start with the first step of the experiment.";
        lines[1] = "\nTo interact with the lab equipment simply walk up to it click on them.";

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


    public void FirstPipettingSuccess()
    {
        lines = new string[2];
        lines[0] = "\nWow! You are doing really good so far.";
        lines[1] = "\nNow we got a wild mix of DNA and cell parts in the tube. Let's separate them!";

        SpeechBubble.StartDialoge(lines);
    }

    public void PipettingIntoFullTube()
    {
        lines = new string[1];
        lines[0] = "\nThe tube is already full. You can't add more liquid to it.";

        SpeechBubble.StartDialoge(lines);
    }

    public void IntroCentrifuge()
    {
        lines = new string[4];
        lines[0] = "\nThe cell debrid and the DNA have different weights (or rather densities). We can use this to our advantage!";
        lines[1] = "\nUsing the centirfuge, we can collect all the heavy stuff at the bottom of our tubes. Our DNA will then be on the top of the tube.";
        lines[2] = "But be careful when using the centrifuge. If the centrifuge is not balanced, an imbalance occurs and the centrifuge can be severely damaged.";
        lines[3] = "\nOnce you have balanced the centrifuge, you can start it by pressing 'E'.";

        Debug.Log("Instructor started");

        SpeechBubble.StartDialoge(lines);
    }

    public void FailCentrifuge()
    {
        lines = new string[2];
        lines[0] = "\nBE CAREFUL! You have to balance the centrifuge first before starting it.";
        lines[1] = "\nLab equipment can be extremely expensive so we dont want to break it!";

        Debug.Log("Instructor started");

        SpeechBubble.StartDialoge(lines);
    }

    public void CentrifugeSuccess()
    {
        lines = new string[1];
        lines[0] = "\nGreat job! Now we can pipette out the now separated DNA.";

        SpeechBubble.StartDialoge(lines);
    }

    public void PipetteTubeWithMixture()
    {
        lines = new string[1];
        lines[0] = "\nI'm sorry, but you can't separate and pipette the liquids if they are already mixed in the tube.";

        SpeechBubble.StartDialoge(lines);
    }

    public void pipetting2()
    {
        lines = new string[4];
        lines[0] = "\nNow we can carefully get the DNA out of the tube.";
        lines[1] = "\nHowever, we have MUCH MUCH more DNA here than just the gene we want.";
        lines[2] = "\nWe have a certain method to replicate only the gene we want. It is called PCR.";
        lines[3] = "\nWe provided you with a special solution that enables this. After pipetting we can then use a special device for this!";
        SpeechBubble.StartDialoge(lines);
    }

    public void ExplainPCR()
    {
        lines = new string[3];
        lines[0] = "\nWith the liquid and the DNA mixed, we now replicate our gene in the PCR-cycler).";
        lines[1] = "\nWhat this PCR-cycler now does is to heat up the liquid and then cool it down again.";
        lines[2] = "Through complex interactions between the genome and the other solutions we will then have millions of copies of our gene of interest.";

        SpeechBubble.StartDialoge(lines);
    }

    public void pipetting3()
    {
        lines = new string[5];
        lines[0] = "\nOur gene is now replicated.";
        lines[1] = "\nBut on its own we cannot simply put it into our superhero E. coli. I would simply be broken down.";
        lines[2] = "\nTherefore we incorporate the gene into a so called plasmid. This way it stays active.";
        lines[3] = "\nAlso this plasmid produces a glowing substance. This way we can later easily see if our work payed out :).";
        lines[4] = "The process is supprisingly similar to the PCR you did before. But here we use other molecular mechanisms that make the two ingredients fuse together.";

        SpeechBubble.StartDialoge(lines);
    }

    public void ExplainGGA()
    {
        lines = new string[2];
        lines[0] = "\nWhat you are doing now is what an expert would call 'Golden Gate Assembly'. Scientist like fancy terms!";
        lines[1] = "\nThe now resulting plasmid will be now carry the gene and sustain it inside the new cell.";

        SpeechBubble.StartDialoge(lines);
    }
    public void pipetting4()
    {
        lines = new string[4];
        lines[0] = "\nAs you see, there is a LOT of pipetting work to do in the lab";
        lines[1] = "\nBut you are doing really good!\nAlso we are really close to our goal now. Only few steps to go!";
        lines[2] = "\nNow we have our plasmids. We simply put them in the same tube with our new bacteria E.coli.";
        lines[3] = "\nWe can then heat shock the E.coli such that they take up the plasmids.";

        SpeechBubble.StartDialoge(lines);
    }

    public void ExplainHeatShock()
    {
        lines = new string[2];
        lines[0] = "\nUsing the PCR machine for heatshocking cells is unconventional, to be honest.";
        lines[1] = "\nBut our lab works on a budget and sometimes you have to utilize machines for something different :).";

        SpeechBubble.StartDialoge(lines);
    }

    public void pipetting5()
    {
        lines = new string[4];
        lines[0] = "\nVery last step: put some bacteria from the tube to the Petri Dish!";

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

