using UnityEngine;

public class Jerry: MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("logic_manager").GetComponent<logic_manager>().return_to_lab(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("logic_manager").GetComponent<logic_manager>().return_to_lab(false);
        }
    }
}
