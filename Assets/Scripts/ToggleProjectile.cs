using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleProjectile : MonoBehaviour
{
    public GameObject trajectoty;
    public Button button;
	private bool show;
    void Start()
    {
        show = false;
        button.GetComponent<Image>().color = new Color(0.7624f, 0.08556f, 0.0958f, 1.0f);
		trajectoty.SetActive(false);
    }
	public void toggleButtons()
    {

        if(show)
        {
            trajectoty.SetActive(false);
			button.GetComponent<Image>().color = new Color(0.7624f, 0.08556f, 0.0958f, 1.0f);
            button.GetComponentInChildren<Text>().color = Color.white;
            show = false;
        }
        else
        {
            trajectoty.SetActive(true);
            button.GetComponent<Image>().color = new Color(0.0151f,0.5f,0f,1.0f);
            show = true;
        }   


    }
}
