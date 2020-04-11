using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class Explorer : MonoBehaviour
{
    
    public Button openExplorerButton;
    public Terrain TerrainMain;

    private bool readText = false;

    void Start()
    {
        ShowExplorer();
    }

    void OnEnable()
    {
        openExplorerButton.onClick.AddListener(delegate{ShowExplorer();});

    }

    void ShowExplorer()
    {
        var process = Process.Start(Environment.CurrentDirectory + @"\Tiff2Raw.exe");
        process.WaitForExit();
        LoadTerrain(Environment.CurrentDirectory + @"\tempFiles\rawFile.raw");
        Info.ShowInfo(Environment.CurrentDirectory + @"\tempFiles\jsonFile.json");
    }

    void LoadTerrain(string aFileName)
    {
        int xRes = TerrainMain.terrainData.heightmapWidth;
        int yRes = TerrainMain.terrainData.heightmapHeight;

            

            //GetHeight - get the heightmap point of terrain
            float [,] heights = TerrainMain.terrainData.GetHeights(0,0,xRes,yRes);

            //Manipulate the heigth data
            using (var file = System.IO.File.OpenRead(aFileName))
            using (var reader = new System.IO.BinaryReader(file))
            {
                for (int y=0 ; y < yRes ; y++)
                {
                    for(int x=0 ; x < xRes ; x++)
                    {
                        float v = (float)reader.ReadByte();
                        heights[yRes - y - 1, x] = v / 1024f;
                        //Debug.Log(v + ",");
                    }
                }
            }
            TerrainMain.terrainData.SetHeights(0,0,heights);

    }
}
