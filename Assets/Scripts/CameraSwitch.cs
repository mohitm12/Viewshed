﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraOne;
	public GameObject cameraTwo;
	public Text btext;
	
    // Start is called before the first frame update
     void Start()
     {
         cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
 }

  	public void switchCamera()
	{
		 	cameraChangeCounter();
	}

    //Camera Counter
	void cameraChangeCounter()
	{
		int cameraPositionCounter=PlayerPrefs.GetInt("CameraPosition");
		cameraPositionCounter++;
		cameraPositionChange(cameraPositionCounter);
	}

    //Camera Change Logic
	void cameraPositionChange(int camPosition)
	{
		if(camPosition > 1)
		{
			camPosition=0;
		}

        PlayerPrefs.SetInt("CameraPosition",camPosition);
		
		if(camPosition == 0)
		{
			cameraOne.SetActive(true);
			cameraTwo.SetActive(false);
			btext.text = "Top View";
		}
		
		if(camPosition == 1)
		{
			cameraOne.SetActive(false);
			cameraTwo.SetActive(true);
			btext.text = "Free Camera";
		}
	}
	
}