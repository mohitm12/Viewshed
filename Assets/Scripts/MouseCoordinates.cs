using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCoordinates : MonoBehaviour
{
    public Text etext;
    private RaycastHit hitInfo;
    private Ray ray;

    List<double> upperLeft = null;
    List<double> lowerLeft = null;
    List<double> lowerRight = null;
    List<double> upperRight = null; 

    double x,y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upperLeft = Info.upperLeft;
        lowerLeft = Info.lowerLeft;
        lowerRight = Info.lowerRight;
        upperRight = Info.upperRight;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, (1<<LayerMask.NameToLayer("Ground"))))
        {
            //transform.position = new Vector3(hitInfo.point.x,hitInfo.point.y,hitInfo.point.z);
            Vector3 point = hitInfo.point;

            x = upperLeft[0] + (point.x / 1024) * (upperRight[0] - upperLeft[0]);
            y = lowerLeft[1] + (point.z / 1024) * (upperLeft[1] - lowerLeft[1]);
            etext.text = x.ToString() + ", " + y.ToString();
        }
    }
}
