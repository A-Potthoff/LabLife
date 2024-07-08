using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CentrifugeController : MonoBehaviour
{
    [SerializeField] private bool Centrifuge_is_balanced = false; //check if the centrifuge is balanced
    [SerializeField] private Holder[] holders; // array of holder transforms (1 to 12)
    [SerializeField] private float rotationDuration = 5f;
    [SerializeField] private TextMeshProUGUI successText;
    private Instructor Instructor;
    private logic_manager logic_Manager;
    private Coroutine rotationCoroutine;
    private bool GameFinished = false;

    private void Start()
    {
        // Initial balance check
        CheckIfBalanced();
        logic_Manager = logic_manager.Instance;
        holders = GetComponentsInChildren<Holder>();
        Instructor = Instructor.Instance; // Get the Instructor instance this way because it is a deactivated singleton from a different scene

        // Ensure the success image is initially hidden
        if (successText != null)
        {
            successText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        CheckIfBalanced();
        // Spin the centrifuge as long as space is pressed and it is balanced
        if (Input.GetKey(KeyCode.E))
        {
            if (Centrifuge_is_balanced)
            {
                if (rotationCoroutine == null)
                {
                    rotationCoroutine = StartCoroutine(RotateCentrifuge());
                }
            }
            else
            {
                if (!GameFinished)
                {
                    Instructor.gameObject.SetActive(true);
                    Instructor.FailCentrifuge();
                }
            }
            
        }
        // Stop rotating the centrifuge if E is released
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (rotationCoroutine != null)
            {
                StopCoroutine(rotationCoroutine);
                rotationCoroutine = null;

                if (!GameFinished)
                {
                    Instructor.gameObject.SetActive(true);
                    Instructor.CentrifugeLonger();
                }
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

    private IEnumerator RotateCentrifuge()
    {
        float elapsedTime = 0f;

        while (Input.GetKey(KeyCode.E) && elapsedTime < rotationDuration)
        {
            // Spin the centrifuge
            transform.Rotate(Vector3.forward * 1000 * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Rotation is done
        if (elapsedTime >= rotationDuration)
        {
            // Trigger text
            if (successText != null)
            {
                successText.gameObject.SetActive(true);
                GameFinished = true;
            }

            // Wait for an additional 10 seconds
            //yield return new WaitForSeconds(2);

            // Call the next action
            logic_Manager.return_to_lab();
        }
    }
}