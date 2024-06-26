﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Fog : MonoBehaviour
{
    float fogDensity;
    FogMode fogMode;
    public Slider slider;
 
    void Start()
    {
        RenderSettings.fog=true;
        RenderSettings.fogMode=FogMode.Exponential;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fogProp()
    {

        RenderSettings.fogDensity = (slider.value)/200;
        Light[] lights = FindObjectsOfType(typeof(Light)) as Light[];
        foreach(Light light in lights)
        {
            if (light.tag == "Light")
            {
                light.intensity = 105 - (slider.value * 100);            
            }
        }
    }
}
