using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Tilemaps;

public class speech_bubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    private string[] lines;
    [SerializeField] private float text_speed;
    private int index;


    //----------------- defining the lines of text ------------------------------------------------------------------
    private void Awake()
    {
        lines = new string[3];
        lines[0] = "Hello, I am a speech bubble";
        lines[1] = "I am here to help you";
        lines[2] = "I am a text box";
    }

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialoge();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
                
        }
    }

    public void StartDialoge()
    {
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
            gameObject.SetActive(false);
        }
    }
}
