using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> dragObject;
    public float snapRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Draggable draggable in dragObject)
        {
            draggable.dragEndedCallback = onDragEnded;
        }
    }

    private void onDragEnded(Draggable draggable)
    {
        float closestDistance = -1;
        Transform colsestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
        {
            float currenDistance= Vector2.Distance(draggable.transform.localPosition,snapPoint.localPosition);
            if(colsestSnapPoint==null||currenDistance< closestDistance)
            {
                colsestSnapPoint=snapPoint;
                closestDistance=currenDistance;
            }
        }
        if(colsestSnapPoint!=null&&closestDistance<=snapRange)
        {
            draggable.transform.localPosition = colsestSnapPoint.localPosition;
        }
    }
}

