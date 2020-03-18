using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CornerCoordinates
{
    public List<double> upperLeft;// { get; set; }
    public List<double> lowerLeft;// { get; set; }
    public List<double> lowerRight;// { get; set; }
    public List<double> upperRight;// { get; set; }
    public List<double> center;// { get; set; }
}