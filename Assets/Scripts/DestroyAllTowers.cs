using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyAllTowers : MonoBehaviour
{
    public GameObject confirmPanel;
    // Start is called before the first frame update
    void Start()
    {
        Image img =  GameObject.Find("DestroyAllPanel").GetComponent<Image>();
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

    public void destroyAllTowers()
    {
        GameObject[] towers =  GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject tower in towers)
        {
            Destroy(tower);
        }
        confirmPanel.SetActive(false);
    }
}
