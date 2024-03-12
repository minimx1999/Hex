using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject);
    public DragEndedDelegate dragEndedCallback;

    public TextMeshProUGUI TextC;
    public TextMeshProUGUI TextD;
    public TextMeshProUGUI TextS;
    public TextMeshProUGUI TextT;

    int textC;
    int textD;
    int textS;
    int textT;

    public bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isCo=false;

    //CheckColidet checkColidet;

    private void OnMouseDown()
    {
        isDragged= true;
        mouseDragStartPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
        isCo = false;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Rotate the object by 30 degrees clockwise around the Z-axis
                transform.Rotate(Vector3.forward, 60f);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
    private void OnMouseUp()
    {
        isDragged=false;
        isCo = true;
        //dragEndedCallback(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //checkColidet= collision.gameObject.GetComponent<CheckColidet>();

        {
            if (collision.transform.tag == "Circle"&& isDragged==false)
            {
                textC += 1;
                TextC.text = textC.ToString();
                Destroy(collision.gameObject);
                Debug.Log("Collision detected with " + collision.gameObject.name);
            }
            if (collision.transform.tag == "Diamond" && isDragged == false)
            {
                textD += 1;
                TextD.text = textD.ToString();
                Destroy(collision.gameObject);
                Debug.Log("Collision detected with " + collision.gameObject.name);
            }
            if (collision.transform.tag == "Square" && isDragged == false)
            {
                textS += 1;
                TextS.text = textS.ToString();
                Destroy(collision.gameObject);
                Debug.Log("Collision detected with " + collision.gameObject.name);
            }
            if (collision.transform.tag == "Triangle" && isDragged == false)
            {
                textT += 1;
                TextT.text = textT.ToString();
                Destroy(collision.gameObject);
                Debug.Log("Collision detected with " + collision.gameObject.name);
            }
        }
        
    }
}
