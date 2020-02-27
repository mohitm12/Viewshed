using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
   public GameObject confirmPanel;
   public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        Image img =  panel.GetComponent<Image>();
         img.color = UnityEngine.Color.white;
        confirmPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openConfirmPanel()
    {
        confirmPanel.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        confirmPanel.SetActive(true);
    }

    public void closeConfirmPanel()
    {
        confirmPanel.SetActive(false);
    }

    public void doExit()
    {
        Application.Quit();
    }
}
