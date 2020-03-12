using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
/* 
    [SerializeField] List<Vector3> pathVertList = new List<Vector3>();
    [SerializeField] float time = 1;
    [Space]
    [SerializeField] float launchMagnitude = 1f;
    [SerializeField] float launchAngle = 45f;
    //[SerializeField] bool preferSmallAng = false;
    [SerializeField] Vector3 velocity = Vector3.right;
    [SerializeField] Vector3 acceleration = Vector3.down;
    [SerializeField] Vector3 unityAccuracyFix = Vector3.zero;
    [SerializeField] int splits = 20;
    [Space]
    [SerializeField] Vector3 targetPos = Vector3.one;

    //Ut + .5 ATT
    public float Distance_AtVel_DueToAcc_InTime(float u, float a, float t)
    {
        return u * t + 0.5f * a * t * t;
    }

    public float Speed_ForDistance_DueToAcc_InTime(float d, float a, float t)
    {
        return (d - Distance_AtVel_DueToAcc_InTime(0, a, t)) / time;
    }

    public float Magnitude_ToReachXY_InGravity_AtAngle(float x, float y, float g, float ang)
    {
        float res = 0;
        float sin2Theta = Mathf.Sin(2 * ang * Mathf.Deg2Rad);
        float cosTheta = Mathf.Cos(ang * Mathf.Deg2Rad);
        float inner = (x * x * g) / (x * sin2Theta - 2 * y * cosTheta * cosTheta);
        if(inner < 0)
        {
            return float.NaN;
        }
        res = Mathf.Sqrt(inner);
        return res;
    }

    public void Calculate_Trajectory()
    {
        if(pathVertList == null)
        {
            pathVertList = new List<Vector3>();
        }
        
        pathVertList.Clear();

        float dt = 0;
        Vector3 d;
        for(int i = 0; i < splits; i++)
        {
            dt = (time / (splits - 1)) * i;
            
            d.x = Distance_AtVel_DueToAcc_InTime(velocity.x, acceleration.x, dt);
            d.y = Distance_AtVel_DueToAcc_InTime(velocity.y, acceleration.y, dt);
            d.z = Distance_AtVel_DueToAcc_InTime(velocity.z, acceleration.z, dt);
            pathVertList.Add(d);
        }
    }

    public void Calculate_Velocity()
    {
        Vector3 d = targetPos - source.position;
        velocity.x = Speed_ForDistance_DueToAcc_InTime(d.x, acceleration.x, time);
        velocity.y = Speed_ForDistance_DueToAcc_InTime(d.y, acceleration.y, time);
        velocity.z = Speed_ForDistance_DueToAcc_InTime(d.z, acceleration.z, time);
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(time);
        projectile.SetActive(false);
    }

    [Header("Ref")]
    [SerializeField] LineRenderer lineRendere = null;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform target;
    [SerializeField] Transform source;
    //[SerializeField] Transform sourcePos;

    [Header("Editor Settings")]
    [SerializeField] bool calc_Trajectory = false;
    [SerializeField] bool calc_Velocity = false;
    //[SerializeField] bool calc_SuitableMagAng = false;
    [SerializeField] bool auto_calc = false;

    [Space]
    [SerializeField] bool fire = false;
    float magChange = 0, angChange = 0;
    Vector3 velChange = Vector3.zero;

    void OnDrawGizmosSelected() 
    {
        if(calc_Trajectory)
        {
            if(!auto_calc)
                calc_Trajectory = false;
            
            Calculate_Trajectory();
            lineRendere.positionCount = splits;
            lineRendere.SetPositions(pathVertList.ToArray());
        }

        if(calc_Velocity)
        {
            if(!auto_calc)
                calc_Velocity = false;

            targetPos = target.transform.position;
            Calculate_Velocity();
            launchAngle = Mathf.Asin(Vector3.Dot(velocity, new Vector3(0,1,0)) / (velocity.magnitude)) * Mathf.Rad2Deg;
            //launchAngle = Vector3.SignedAngle(Vector3.right, velocity, Vector3.down);
            launchMagnitude = velocity.magnitude;
        }

        if(fire)
        {
            fire = false;
            projectile.SetActive(true);
            projectile.transform.position = source.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = velocity + unityAccuracyFix;
            
            //yield return new WaitForSeconds(time);
            //projectile.SetActive(false);
            StartCoroutine(LateCall());
        }
    }

    private void OnDrawGizmos() 
    {
        if(auto_calc)
        {
            OnDrawGizmosSelected();
        }    
    }
*/
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    [SerializeField] Vector3 velocity;
    [SerializeField] static int splits = 20;
    [SerializeField] Vector3 acceleration = new Vector3(0f, -9.81f, 0f);
    [SerializeField] Vector3[] pathVertList = new Vector3[splits];
    [SerializeField] float launchMagnitude = 1f;
    [SerializeField] float launchAngle = 45f;
    //[SerializeField] LineRenderer lineRenderer = null;
    public LineRenderer lineRenderer;

    public float time = 2;

    public float Distance_AtVel_DueToAcc_InTime(float u, float a, float t)
    {
        return u * t + 0.5f * a * t * t;
    }

    public float Speed_ForDistance_DueToAcc_InTime(float d, float a, float t)
    {
        return (d - Distance_AtVel_DueToAcc_InTime(0, a, t)) / time;
    }

    public void Calculate_Velocity()
    {
        Vector3 d = pointB - pointA;
        velocity.x = Speed_ForDistance_DueToAcc_InTime(d.x, acceleration.x, time);
        velocity.y = Speed_ForDistance_DueToAcc_InTime(d.y, acceleration.y, time);
        velocity.z = Speed_ForDistance_DueToAcc_InTime(d.z, acceleration.z, time);
    }

    public void Calculate_Trajectory()
    {

        float dt = 0;
        Vector3 d;
        for(int i = 0; i < splits ; i++)
        {
            dt = (time / (splits - 1)) * i;
            
            d.x = Distance_AtVel_DueToAcc_InTime(velocity.x, acceleration.x, dt);
            d.y = Distance_AtVel_DueToAcc_InTime(velocity.y, acceleration.y, dt);
            d.z = Distance_AtVel_DueToAcc_InTime(velocity.z, acceleration.z, dt);
            //Debug.Log(i);
            pathVertList[i] = d;
        }

       //pathVertList.Add(pointB);
    }

    void Start()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.SetWidth(.4f, .4f);
    }

    void Update()
    {
        GameObject source = GameObject.Find("Source");
        pointA = source.transform.position;
        pointB = gameObject.transform.position;
    

        Calculate_Velocity();

        launchAngle = Mathf.Asin(Vector3.Dot(velocity, new Vector3(0,1,0)) / (velocity.magnitude)) * Mathf.Rad2Deg;
        //launchAngle = Vector3.SignedAngle(Vector3.right, velocity, Vector3.down);
        launchMagnitude = velocity.magnitude;

        Calculate_Trajectory();
        
        lineRenderer.positionCount = splits;
        
        lineRenderer.SetPositions(pathVertList);

        bool obstructionFlag = false;

        for(int i=1 ; i < splits - 2 ; i++)
        {
            Vector3 direction = pathVertList[i+1] - pathVertList[i];

            RaycastHit hit;
            if(Physics.Raycast(pathVertList[i], direction, out hit))
            {
                Debug.DrawRay(pathVertList[i], direction, Color.yellow);
                if(hit.collider.gameObject.tag == "Terrain")
                {
                    obstructionFlag = true;
                }
            }

            if(obstructionFlag)
            {
                lineRenderer.material.color = new Color(1,0,0,1);
            }
            else
            {
                lineRenderer.material.color = new Color(0,1,0,1);
            }
        }
    }
}
