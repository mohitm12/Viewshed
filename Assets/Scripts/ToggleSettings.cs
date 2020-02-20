using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettings : MonoBehaviour
{
     public GameObject settings;
	//int counter;
    private bool show;
    void Start()
    {
        settings.SetActive(false);
        // counter = 0;
        show = false;
    }
	public void toggleSettings()
    {

        if(show)
        {
            settings.SetActive(false);  
            show = false;
        }
        else
        {
            settings.SetActive(true);
            show = true;
        }        

	 	//changeCounter();
    }
}
