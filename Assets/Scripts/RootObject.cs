using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RootObject
{
    public string description;// { get; set; }
    public string driverShortName;// { get; set; }
    public string driverLongName;// { get; set; }
    public List<string> files;// { get; set; }
    public List<int> size;// { get; set; }
    public List<double> geoTransform;// { get; set; }
    public CornerCoordinates cornerCoordinates;// { get; set; }
    public Extent extent;// { get; set; }
    public List<Band> bands;// { get; set; }
}