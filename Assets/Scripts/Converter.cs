using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class Converter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void runFile()
    {
        Process.Start(Environment.CurrentDirectory + @"\Tiff2Raw.exe");
    }
}
