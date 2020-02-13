using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private LineRenderer lineRenderer;
    
    //public Transform origin;
    //public Transform destination;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(.4f, .4f);

    }

    // Update is called once per frame
    void Update()
    {
        GameObject origin = GameObject.Find("Origin");
        Vector3 pointA = origin.transform.position;
        Vector3 pointB = destination.position;
        Vector3 direction = pointB - pointA;

        RaycastHit hit;
        if(Physics.Raycast(origin.transform.position,direction, out hit))
        {
            if(hit.collider.gameObject.tag == "Target")
                lineRenderer.material.color = new Color(0,1,0,1);
            else
                lineRenderer.material.color = new Color(1,0,0,1);
        }
        lineRenderer.SetPosition(0, pointA);
        lineRenderer.SetPosition(1, pointB);
    }
}
