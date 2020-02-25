using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class ToggleDestroyer : MonoBehaviour
{
	
//	public GameObject spawnee;
	public Button button;
	private RaycastHit hit;
    private Ray ray;
    private bool destroy;
    void Start()
    {
        destroy = false;
		
    }
	public void toggleButtons()
    {

        if(destroy)
        {
            destroy = false;
			button.GetComponent<Image>().color = new Color(0.3686f,0.3411f,0.3254f,1.0f);
			button.GetComponentInChildren<Text>().color = Color.white;
        }
        else
        {
            destroy = true;
			button.GetComponent<Image>().color = new Color(0.7624f, 0.08556f, 0.0958f, 1.0f);
        }   


    }
	void Update()
	{
		if(destroy)
		{
			if (Input.GetMouseButtonDown(0))
     		{
        		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      
        		if (Physics.Raycast(ray, out hit))
        		{
					if(hit.collider.gameObject.tag == "Tower" || hit.collider.gameObject.tag == "Target")
	           			Destroy(hit.collider.gameObject);
           		}  
     		}
		}
	}     




    // void Start()
    // {
    //     ToggleRemover(PlayerPrefs.GetInt("Counter"));
    // }
	// public void remover()
    // {
	//  	changeCounter();
    // }
	// void changeCounter()
	// {
	// 	int counter = PlayerPrefs.GetInt("Counter");
	// 	counter++;
	// 	ToggleRemover(counter);
	// }

	// void ToggleRemover(int counter)
	// {
	// 	if(counter > 1)
	// 	{
	// 		counter=0;
	// 	}

    //     PlayerPrefs.SetInt("Counter",counter);
		
	// 	if(counter == 0)
	// 	{
	// 		spawnee.SetActive(true);
	// 	}
		
	// 	if(counter == 1)
	// 	{
	// 		spawnee.SetActive(false);
	// 	}	
	// }
}
