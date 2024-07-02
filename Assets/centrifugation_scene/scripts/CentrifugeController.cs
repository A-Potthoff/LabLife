using UnityEngine;

public class CentrifugeController : MonoBehaviour
{
    [SerializeField] private bool Centrifuge_is_balanced = false; //check if the centrifuge is balanced
    [SerializeField] private Holder[] holders; // array of holder transforms (1 to 12)
    private Instructor Instructor;

    private void Start()
    {
        // Initial balance check
        CheckIfBalanced();
        holders = GetComponentsInChildren<Holder>();
        Instructor = Instructor.Instance; // Get the Instructor instance this way because it is a deactivated singleton from a different scene
    }

    private void Update()
    {
        CheckIfBalanced();
        // Spin the centrifuge as long as space is pressed and it is balanced
        if (Input.GetKey(KeyCode.E))
        {
            if (Centrifuge_is_balanced)
            {
                //Spin the centrifuge
                transform.Rotate(Vector3.forward * 1000 * Time.deltaTime);
            }
            else
            {
                Instructor.gameObject.SetActive(true);
                Instructor?.FailCentrifuge();
            }
        }
    }

    public void CheckIfBalanced()
    {
        Centrifuge_is_balanced = true; // Assume it is balanced until proven otherwise

        int half = holders.Length / 2;

        for (int i = 0; i < half; i++)
        {
            Holder holder1 = holders[i];
            Holder holder2 = holders[i + half];

            if (holder1.filled != holder2.filled)
            {
                // If one is filled and the corresponding one is not, it is not balanced
                Centrifuge_is_balanced = false;
            }
        }
    }
}