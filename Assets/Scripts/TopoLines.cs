 using UnityEngine;
 using System.Collections;
 
 
 public class TopoLines : MonoBehaviour 
 {
     public Terrain terrain;
     
     public int numberOfBands = 12;
     
     public Color bandColor = Color.white;
     public Color bkgColor = Color.clear;
     
     public Renderer outputPlain;
     
     public Texture2D topoMap;
     
     
     void Start() 
     {
         GenerateTopoLines();
     }
     
     void Update() 
     {
         if ( Input.GetMouseButtonDown(0) )
         {
             GenerateTopoLines();
         }
     }
     
     void GenerateTopoLines() 
     {
         //topoMap = ContourMap.FromTerrain( terrain );
         //topoMap = ContourMap.FromTerrain( terrain, numberOfBands );
         topoMap = ContourMap.FromTerrain( terrain, numberOfBands, bandColor, bkgColor );
         
         if ( outputPlain )
         {
             outputPlain.material.mainTexture = topoMap;
         }
     }
 }