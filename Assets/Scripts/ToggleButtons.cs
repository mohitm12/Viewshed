using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour
{
    public GameObject buttons;
	//int counter;
    private bool show;
    void Start()
    {
        buttons.SetActive(false);
        // counter = 0;
        show = false;
    }
	public void toggleButtons()
    {

        if(show)
        {
            buttons.SetActive(false);  
            show = false;
        }
        else
        {
            buttons.SetActive(true);
            show = true;
        }        

	 	//changeCounter();
    }
	// void changeCounter()
	// {
	// 	counter++;
	// 	ToggleButtons(counter);
	// }

	// void ToggleButtons(int counter)
	// {
	// 	//GameObject losOrigin;
	// 	//losOrigin = GameObject.Find("Origin");
		
	// 	if(counter > 1)
	// 	{
	// 		counter=0;
	// 	}
		
	// 	if(counter == 1)
	// 	{
	// 		buttons.SetActive(true);
	// 	}
		
	// 	if(counter == 0)
	// 	{
    //         buttons.SetActive(false);
    //     }	

    //     Debug.Log(counter);
	// }
}
