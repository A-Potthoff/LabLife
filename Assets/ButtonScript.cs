using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void OpenSurvey(string url = "https://docs.google.com/forms/d/e/1FAIpQLSdTjuDezu1C8yJS58AH-wKcz99i1xsibDpVfkekhRnJlBqnmA/viewform?usp=sf_link")
    {
        Application.OpenURL(url);
    }
}
