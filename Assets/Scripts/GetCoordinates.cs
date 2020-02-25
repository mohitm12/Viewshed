using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoordinates : MonoBehaviour
{
    public Text ctext;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] towers;
        towers = GameObject.FindGameObjectsWithTag("Tower");
        ctext.text = "";
        int i = 0;
        foreach(GameObject tower in towers)
        {
            Vector3 point = tower.transform.position;
          //  point.x += 512;
         //   point.z += 512;
            i++;
            ctext.text +="Tower " + i + " : [ "+ point.x.ToString() + " , " + point.z.ToString() + " ]";
            ctext.text += "\n\n";
        }     
            
    }
}
