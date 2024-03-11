using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrabbed = false;
    private Vector2 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Change to touch input if targeting mobile platforms
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isGrabbed = true;
                lastPosition = rb.position - mousePosition;
                Debug.Log("yes");
            }
        }

        if (Input.GetMouseButtonUp(0) && isGrabbed)
        {
            isGrabbed = false;
        }

        if (isGrabbed)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(mousePosition + lastPosition);
        }
    }
}
