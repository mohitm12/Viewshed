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
        foreach(GameObject tower in towers)
        {
            Vector3 point = tower.transform.position;
            point.x += 512;
            point.z += 512;
            ctext.text +="[ "+ point.x.ToString() + " , " + point.z.ToString() + " ]";
            ctext.text += "\n";
        }     
            
    }
}
