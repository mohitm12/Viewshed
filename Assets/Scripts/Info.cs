using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SmartDLL;
using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

public class Info : MonoBehaviour
{
    public static double min, max;
    public static List<double> upperLeft;
    public static List<double> lowerLeft;
    public static List<double> lowerRight;
    public static List<double> upperRight;

    
    private bool readText = false;

   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ShowInfo(string fileName)
    {
        String json = File.ReadAllText(fileName);
        RootObject rootObject = JsonUtility.FromJson<RootObject>(json);

        min = rootObject.bands[0].min;
        max = rootObject.bands[0].max;

        upperLeft = rootObject.cornerCoordinates.upperLeft;
        lowerLeft = rootObject.cornerCoordinates.lowerLeft;
        lowerRight = rootObject.cornerCoordinates.lowerRight;
        upperRight = rootObject.cornerCoordinates.upperRight;

        UnityEngine.Debug.Log("Done " + rootObject.extent.type + " Min-Max = " + rootObject.bands[0].min);
    }
}
