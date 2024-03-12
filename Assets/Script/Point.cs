using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public TextMeshProUGUI TextC;
    public TextMeshProUGUI TextD;
    public TextMeshProUGUI TextS;
    public TextMeshProUGUI TextT;

    int textC;
    int textD;
    int textS;
    int textT;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Circle")
        {
            textC += 1;
            TextC.text=textC.ToString();
            Destroy(collision.gameObject);
        }
        // Handle collision
        Debug.Log("Collision detected with " + collision.gameObject.name);
    }
}
