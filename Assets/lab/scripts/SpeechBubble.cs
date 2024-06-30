using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Tilemaps;

public class SpeechBubble : MonoBehaviour
{
    private static Instructor instance; 
    [SerializeField] private TextMeshProUGUI textComponent;
    private string[] _lines;
    private string[] lines;
    [SerializeField] private float text_speed;
    private int index;
    private GameObject Instructor;

    //----------------- defining the lines of text ------------------------------------------------------------------

    void Start()
    {
        textComponent.text = string.Empty;
        Instructor = GameObject.Find("Instructor");
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
        this.lines = _lines;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() // types the text char by char
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(text_speed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            //deactivate the speech bubble when the dialoge is over
            Instructor.SetActive(false);
        }
    }

}
