using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projLOS : MonoBehaviour
{
    public LineRenderer lineRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] pathVertList = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(pathVertList);

        for(int i=0 ; i < lineRenderer.positionCount - 1 ; i++)
        {
            Vector3 direction = pathVertList[i+1] - pathVertList[i];

            RaycastHit hit;
            if(Physics.Raycast(pathVertList[i] ,direction, out hit))
            {
                if(hit.collider.gameObject.tag == "Target")
                {
                    lineRenderer.material.color = Color.red;
                    
                }
            }
        }   
    }
}
