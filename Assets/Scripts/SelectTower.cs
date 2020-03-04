using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTower : MonoBehaviour
{
    public GameObject panel;
    private RaycastHit hit;
    private Ray ray;
    private bool show;
    public Text stext;
    public InputField irange;
    private GameObject tower;
    public GameObject inputSpace;
    
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        inputSpace.SetActive(false);
        show = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if(show)
        {
            if (Input.GetMouseButtonDown(0))
     		{
        		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      
        		if (Physics.Raycast(ray, out hit))
        		{
					if(hit.collider.gameObject.tag == "Tower")
	           		{

                        stext.text = "Adjust Range : ";
                        inputSpace.SetActive(true);
                        tower = hit.collider.gameObject;
                        Debug.Log(tower.name);
                       }
           		}  
     		}
        }
    }

    public void selectTower()
    {
       
        if (show)
        {
            stext.text = "Select a Tower";
            inputSpace.SetActive(false);
            panel.SetActive(false);
            show = false;
        }
        else
        {
            Image img =  panel.GetComponent<Image>();
            img.color = UnityEngine.Color.white;
            panel.SetActive(true);
            show = true;
        }
    }

    public void changeRange()
    {
        Light light = tower.GetComponentInChildren<Light>();
       float range;

        if(irange.text.Length == 0)
        {
            range = 300;
        }
        else
        {
            range = float.Parse(irange.text);
        }

        light.range = range;
    }
}
