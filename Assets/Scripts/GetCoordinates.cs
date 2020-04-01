using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoordinates : MonoBehaviour
{
    public Text ctext;

    List<double> upperLeft = null;
    List<double> lowerLeft = null;
    List<double> lowerRight = null;
    List<double> upperRight = null;

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

        GameObject[] towers;
        towers = GameObject.FindGameObjectsWithTag("Tower");
        ctext.text = "";
        int i = 0;
        double x,y;
        foreach(GameObject tower in towers)
        {
            Vector3 point = tower.transform.position;
            i++;

            x = upperLeft[0] + (point.x / 1024) * (upperRight[0] - upperLeft[0]);
            y = lowerLeft[1] + (point.z / 1024) * (upperLeft[1] - lowerLeft[1]); 

            ctext.text +="Tower " + i + " : [ "+ x.ToString() + " ,\n            " + y.ToString() + " ]";
            ctext.text += "\n\n";
        }     
            
    }
}
