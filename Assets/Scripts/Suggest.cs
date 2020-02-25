﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suggest : MonoBehaviour
{
    public Terrain terrain;
    public GameObject tower;
    
    public void suggestTower()
    {
        int xRes = (int)terrain.terrainData.size.x;
        int yRes = (int)terrain.terrainData.size.z;

        int x1 = xRes / 2;
        int y1 = yRes / 2;

        //float [,] heights = terrain.terrainData.GetHeights(0,0,xRes,yRes);

        float max1 = 0, max2 = 0, max3 = 0, max4 = 0;
        int max1i = 0 , max1j = 0, max2i = 0, max2j = 0, max3i = 0, max3j = 0, max4i = 0, max4j = 0;
        
        // 1st quadrant
        for(int i = 0 ; i < x1 ; i++ )
        {
            for(int j = 0 ; j < y1 ; j++ )
            {
                //terrain.SampleHeight(new Vector3(i, 0 ,j))
                if( terrain.SampleHeight(new Vector3(i, 0 ,j)) > max1 )
                {
                    max1i = i;
                    max1j = j;
                    max1 = terrain.SampleHeight(new Vector3(i, 0 ,j));
                }
            }
        }
        Instantiate(tower, new Vector3(max1i, max1, max1j), Quaternion.identity);

        //2nd quadrant
        for(int i = x1 ; i < xRes ; i++ )
        {
            for(int j = 0 ; j < y1 ; j++ )
            {
                //terrain.SampleHeight(new Vector3(i, 0 ,j))
                if( terrain.SampleHeight(new Vector3(i, 0 ,j)) > max2 )
                {
                    max2i = i;
                    max2j = j;
                    max2 = terrain.SampleHeight(new Vector3(i, 0 ,j));
                }
            }
        }
        Instantiate(tower, new Vector3(max2i, max2, max2j), Quaternion.identity);

        //3rd quadrant
        for(int i = 0 ; i < x1 ; i++ )
        {
            for(int j = y1 ; j < yRes ; j++ )
            {
                //terrain.SampleHeight(new Vector3(i, 0 ,j))
                if( terrain.SampleHeight(new Vector3(i, 0 ,j)) > max3 )
                {
                    max3i = i;
                    max3j = j;
                    max3 = terrain.SampleHeight(new Vector3(i, 0 ,j));
                }
            }
        }
        Instantiate(tower, new Vector3(max3i, max3, max3j), Quaternion.identity);

        //4th quadrant
        for(int i = x1 ; i < xRes ; i++ )
        {
            for(int j = y1 ; j < yRes ; j++ )
            {
                //terrain.SampleHeight(new Vector3(i, 0 ,j))
                if( terrain.SampleHeight(new Vector3(i, 0 ,j)) > max4 )
                {
                    max4i = i;
                    max4j = j;
                    max4 = terrain.SampleHeight(new Vector3(i, 0 ,j));
                }
            }
        }
        Instantiate(tower, new Vector3(max4i, max4, max4j), Quaternion.identity);
        //Debug.Log(heights);
        //Debug.Log(maxi + ", " + maxj + ", " + max);
    }
}