using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disclaimer : MonoBehaviour
{

    private Instructor Instructor;

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
            //destroy the disclaimer
            Destroy(gameObject);
            
        }
    }
}
