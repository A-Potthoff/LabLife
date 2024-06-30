using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    private static Instructor instance;
    private string[] lines;
    private SpeechBubble SpeechBubble;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SpeechBubble = GameObject.Find("SpeechBubble").GetComponent<SpeechBubble>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartIntroduction()
    {
        lines = new string[3];
        lines[0] = "Hey there! \n Welcome to our lab, we are very happy you decided to pursue your PhD here! We also already have the first important task for you!";
        lines[1] = "Not long ago researchers found a new plastic degrading bacterium inside the ocean! However, they grow really really slow, which makes it practically impossible to use them in the lab...";
        lines[2] = "Therefore we wanna take the gene that is responsible for this degradation out of the bactierum and set it into E.coli. E.coli are fast growing bacteria we know very well.";

        Debug.Log("Instructor started");

        SpeechBubble.StartDialoge(lines);
    }




}
