using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightController : MonoBehaviour
{
    /*private Vector3 offset;
    private Transform currentHolder = null;

    //----------------------------- mouse movement ------------------------------------

    void OnMouseDown() //necessary to calculate the offset
    {
        // Convert mouse position to world position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the offset between the mouse position and the pipette's position
        offset = transform.position - worldPosition;
    }

    void OnMouseDrag() // the actual movement of the pipette
    {
        // Convert mouse position to world position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Apply the offset to keep the pipette from jumping to the mouse position
        transform.position = worldPosition + offset;
    }

    //----------------------------- interaction with centrifuge ------------------------

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Holder"))
        {
            currentHolder = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Holder"))
        {
            if (currentHolder == other.transform)
            {
                currentHolder = null;
            }
        }
    }
    */

    private bool isDragging = false;
    private Vector3 offset;
    private Transform currentHolder = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                isDragging = true;
                offset = transform.position - mousePos;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            if (currentHolder != null)
            {
                // Snap to the holder
                transform.position = currentHolder.position;
                transform.SetParent(currentHolder);
            }
        }

        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Holder"))
        {
            currentHolder = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Holder"))
        {
            if (currentHolder == other.transform)
            {
                currentHolder = null;
            }
        }
    }


}
