using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Toggle : MonoBehaviour
{
	
	public GameObject losOrigin;
	
	
    void Start()
    {
        ToggleLOS(PlayerPrefs.GetInt("Counter"));
    }
	public void toggleLos()
    {
	 	changeCounter();
    }
	void changeCounter()
	{
		int counter = PlayerPrefs.GetInt("Counter");
		counter++;
		ToggleLOS(counter);
	}

	void ToggleLOS(int counter)
	{
		//GameObject losOrigin;
		//losOrigin = GameObject.Find("Origin");
		
		if(counter > 1)
		{
			counter=0;
		}

        PlayerPrefs.SetInt("Counter",counter);
		
		if(counter == 0)
		{
			GameObject[] losTargets = FindInActiveObjectsByTag("Target");
			losOrigin.SetActive(true);
			foreach(GameObject losTarget in losTargets)
			{
				losTarget.SetActive(true);
			}
		}
		
		if(counter == 1)
		{
			GameObject[] losTargets = GameObject.FindGameObjectsWithTag("Target");
			losOrigin.SetActive(false);
			foreach(GameObject losTarget in losTargets)
			{
				losTarget.SetActive(false);
			}
		}	
	}

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