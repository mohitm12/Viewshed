using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustRange : MonoBehaviour
{
    private Light[] lights;
    public InputField inputRange;
   // private bool change = false;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(change)
        // {
        //     lights = FindObjectsOfType(typeof(Light)) as Light[];

        //     float range;

        //     if(inputRange.text.Length == 0)
        //     {
        //         range = 300;
        //     }
        //     else
        //     {
        //         range = float.Parse(inputRange.text);
        //     }

        //     foreach (Light l in lights)
        //     {
        //         l.range = range * (1  - slider.value);
        //     }

        //     //inputRange.placeholder.GetComponent<Text>().text = (range * (1  - slider.value)).ToString();
        //     change = false;
        // }
    }

    public void changeRange()
    {
        lights = FindObjectsOfType(typeof(Light)) as Light[];

            float range;

            if(inputRange.text.Length == 0)
            {
                range = 300;
            }
            else
            {
                range = float.Parse(inputRange.text);
            }

            foreach (Light l in lights)
            {
                l.range = range;// * (1  - slider.value);
            }

        //change = true;
    }

    public void onSliderChange()
    {
        //change = true;
        lights = FindObjectsOfType(typeof(Light)) as Light[];

            float range;

            if(inputRange.text.Length == 0)
            {
                range = 300;
            }
            else
            {
                range = float.Parse(inputRange.text);
            }

            foreach (Light l in lights)
            {
                l.range = range * (1  - slider.value);
            }
            // inputRange.placeholder.GetComponent<Text>().text = (range * (1  - slider.value)).ToString();

    }
}
