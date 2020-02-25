using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
	
	public GameObject losOrigin;
	public Button button;
	public GameObject addButton;
    private bool show;
	
    void Start()
    {
		show = false;
		losOrigin.SetActive(false);
		addButton.SetActive(false);
		button.GetComponent<Image>().color = new Color(0.7624f, 0.08556f, 0.0958f, 1.0f);
        //button.GetComponentInChildren<Text>().color = Color.white;
        //ToggleLOS(PlayerPrefs.GetInt("Counter"));
    }
	public void toggleLos()
    {
	 	//changeCounter();
		  if(show)
        {
             
            
            //button.GetComponentInChildren<Text>().color = Color.white;
			button.GetComponent<Image>().color = new Color(0.7624f, 0.08556f, 0.0958f, 1.0f);
			GameObject[] losTargets = GameObject.FindGameObjectsWithTag("Target");
			losOrigin.SetActive(false);
			foreach(GameObject losTarget in losTargets)
			{
				losTarget.SetActive(false);
			}
			addButton.SetActive(false);
            show = false;
        }
        else
        {
            //button.GetComponentInChildren<Text>().color = Color.white;
            
            
			button.GetComponent<Image>().color = new Color(0.0151f,0.5f,0f,1.0f);
			GameObject[] losTargets = FindInActiveObjectsByTag("Target");
			losOrigin.SetActive(true);
			foreach(GameObject losTarget in losTargets)
			{
				losTarget.SetActive(true);
			}
			addButton.SetActive(true);

            show = true;
        }  
    }
	// void changeCounter()
	// {
	// 	int counter = PlayerPrefs.GetInt("Counter");
	// 	counter++;
	// 	ToggleLOS(counter);
	// }

	// void ToggleLOS(int counter)
	// {
	// 	//GameObject losOrigin;
	// 	//losOrigin = GameObject.Find("Origin");
		
	// 	if(counter > 1)
	// 	{
	// 		counter=0;
	// 	}

    //     PlayerPrefs.SetInt("Counter",counter);
		
	// 	if(counter == 0)
	// 	{
	// 		GameObject[] losTargets = FindInActiveObjectsByTag("Target");
	// 		losOrigin.SetActive(true);
	// 		foreach(GameObject losTarget in losTargets)
	// 		{
	// 			losTarget.SetActive(true);
	// 		}
	// 	}
		
	// 	if(counter == 1)
	// 	{
	// 		GameObject[] losTargets = GameObject.FindGameObjectsWithTag("Target");
	// 		losOrigin.SetActive(false);
	// 		foreach(GameObject losTarget in losTargets)
	// 		{
	// 			losTarget.SetActive(false);
	// 		}
	// 	}	
	// }

	GameObject[] FindInActiveObjectsByTag(string tag)
	{
		List<GameObject> validTransforms = new List<GameObject>();
		Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
		for (int i = 0; i < objs.Length; i++)
		{
			if (objs[i].hideFlags == HideFlags.None)
			{
				if (objs[i].gameObject.CompareTag(tag))
				{
					validTransforms.Add(objs[i].gameObject);
				}
			}
		}
		return validTransforms.ToArray();
	}
}