using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSunMovement : MonoBehaviour
{
    public GameObject settings;
//	public Button button;
    private bool show;
    void Start()
    {
        settings.SetActive(false);
        show = false;
    }
	public void toggleSettings()
    {

        if(show)
        {
            settings.SetActive(false);  
//            button.GetComponent<Image>().color = new Color(0.3686f,0.3411f,0.3254f,1.0f);
  //          button.GetComponentInChildren<Text>().color = Color.white;
            show = false;
        }
        else
        {
            settings.SetActive(true);
    //        button.GetComponent<Image>().color = new Color(0.8f,0.8f,0.8f,1.0f);
      //      button.GetComponentInChildren<Text>().color = Color.black;
            
            //button.GetComponent<Image>().color = new Color(0.0293f,0.566f,0.0786f,1.0f);
            show = true;
        }        
    }
}
