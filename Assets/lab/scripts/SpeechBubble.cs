using UnityEngine;
using TMPro;
using System.Collections;

public class SpeechBubble : MonoBehaviour
{
    private static Instructor instance;
    [SerializeField] private TextMeshProUGUI textComponent;
    private string[] _lines;
    private string[] lines;
    [SerializeField] private float text_speed;
    private int index;
    private Instructor Instructor;
    private Coroutine typingCoroutine;
    public bool isActive; // for OutroScript

    //----------------- defining the lines of text ------------------------------------------------------------------

    void Start()
    {
        textComponent.text = string.Empty;
        Instructor = Instructor.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text != lines[index])
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
            else
            {
                NextLine();
            }
        }
    }
    public void StartDialoge(string[] _lines)
    {
        isActive = true;
        this.lines = _lines;
        index = 0;

        // Stop any existing typing coroutine before starting a new one
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Start the typing coroutine
        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() // types the text char by char
    {
        textComponent.text = string.Empty;

        foreach (char c in this.lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(text_speed);
        }
    }

    public void NextLine()
    {
        if (index < this.lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;

            // Stop any existing typing coroutine before starting a new one
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            typingCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            //deactivate the speech bubble when the dialoge is over
            Instructor.gameObject.SetActive(false);
            isActive = false;
        }
    }
}
