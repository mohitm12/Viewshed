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

    public Button openExplorerButton;
    public SmartFileExplorer fileExplorer = new SmartFileExplorer();
    private bool readText = false;

    void OnEnable() 
    {
        openExplorerButton.onClick.AddListener(delegate{ShowExplorer();});    
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fileExplorer.resultOK && readText)
        {
            ShowInfo(fileExplorer.fileName);
            readText = false;
        }
    }

    void ShowExplorer()
    {
        string initialDir = @"C:\";
        bool restoreDir = true;
        string title = "Open a file";
        string defExt = "json";
        string filter = "Json file |*.json";

        //Debug.Log("ShowExplorer()");

        fileExplorer.OpenExplorer(initialDir,restoreDir,title,defExt,filter);
        readText = true;
    }

    void ShowInfo(string fileName)
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
