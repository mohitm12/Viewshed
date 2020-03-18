using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Band
{
    public int band;// { get; set; }
    public List<int> block;// { get; set; }
    public string type;// { get; set; }
    public string colorInterpretation;// { get; set; }
    public double min;// { get; set; }
    public double max;// { get; set; }
    public double minimum;// { get; set; }
    public double maximum;// { get; set; }
    public double mean;// { get; set; }
    public double stdDev;// { get; set; }
}