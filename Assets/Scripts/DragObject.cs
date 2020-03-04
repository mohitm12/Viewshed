using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragObject : MonoBehaviour
{
    static bool drag;
    private void Start() {
        drag = true;
    }

    private void Update() {
        
    }

    public void toggleDrag()
    {
        if(drag)
            drag = false;
        else
            drag = true;
    }

    void OnMouseDrag() {
        if(drag)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction*100f);
            if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, (1<<LayerMask.NameToLayer("Ground"))))
            {
                transform.position = new Vector3(hitInfo.point.x,hitInfo.point.y,hitInfo.point.z);
            }
        }
    }
}
