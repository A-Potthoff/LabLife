using UnityEngine;

public class Instructor : MonoBehaviour
{
    private static Instructor instance;
    private string[] lines;
    private SpeechBubble SpeechBubble;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SpeechBubble = GameObject.Find("SpeechBubble").GetComponent<SpeechBubble>();
            spriteRenderer = GetComponent<SpriteRenderer>();
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
}
