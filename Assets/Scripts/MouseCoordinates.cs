using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCoordinates : MonoBehaviour
{
    public Text etext;
    private RaycastHit hitInfo;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, (1<<LayerMask.NameToLayer("Ground"))))
        {
            //transform.position = new Vector3(hitInfo.point.x,hitInfo.point.y,hitInfo.point.z);
            etext.text = hitInfo.point.ToString();
        }
    }
}
