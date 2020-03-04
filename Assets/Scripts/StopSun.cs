using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopSun : MonoBehaviour
{
    bool use;
    public Light light;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        use = true;
        light.GetComponent<SunMovement>().enabled = true;
        text.text = "Stop Sun";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stopSun()
    {
        if (use)
        {
            text.text = "Start Sun";
            light.GetComponent<SunMovement>().enabled = false;
            use = false;
        }
        else
        {
            text.text = "Stop Sun";
            light.GetComponent<SunMovement>().enabled = true;
            use = true;
        }
    }

}
