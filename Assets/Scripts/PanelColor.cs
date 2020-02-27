using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] panels =FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject panel in panels)
        {
            if (panel.name == "Panel")
            {
                Image img =  panel.GetComponent<Image>();
                img.color = UnityEngine.Color.white;            
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
