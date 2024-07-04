using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disclaimer : MonoBehaviour
{

    private Instructor Instructor;
    private static Disclaimer Instance;
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

    void Start()
    {
        Instructor = Instructor.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //if enter is clicked
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instructor.StartIntroduction();
            //deactivate the disclaimer
            this.gameObject.SetActive(false);
        }
    }
}
