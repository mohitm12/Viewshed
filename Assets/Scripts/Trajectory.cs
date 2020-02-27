using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] List<Vector3> pathVertList = new List<Vector3>();
    [SerializeField] float time = 1;
    [Space]
    [SerializeField] float launchMagnitude = 1f;
    [SerializeField] float launchAngle = 45f;
    [SerializeField] bool preferSmallAng = false;
    [SerializeField] Vector3 velocity = Vector3.right;
    [SerializeField] Vector3 acceleration = Vector3.down;
    [SerializeField] Vector3 unityAccuracyFix = Vector3.zero;
    [SerializeField] int splits = 3;
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

    public float Angle_ToReachXY_InGravity_AtMagnitude(float x, float y, float g, float mag) 
    {
        float innerSq = Mathf.Pow(mag, 4) - g * (g * x * x + 2 * y * mag * mag);
        if(innerSq < 0)
        {
            return float.NaN;
        }
        float innerATan;
        if(preferSmallAng)
        {
            innerATan = (mag * mag - Mathf.Sqrt(innerSq)) / (g * x);
        }
        else
        {
            innerATan = (mag * mag + Mathf.Sqrt(innerSq)) / (g * x);            
        }

        float res = Mathf.Atan(innerATan) * Mathf.Rad2Deg;
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
        Vector3 d = targetPos - transform.position;
        velocity.x = Speed_ForDistance_DueToAcc_InTime(d.x, acceleration.x, time);
        velocity.y = Speed_ForDistance_DueToAcc_InTime(d.y, acceleration.y, time);
        velocity.z = Speed_ForDistance_DueToAcc_InTime(d.z, acceleration.z, time);
    }

    [Header("Ref")]
    [SerializeField] LineRenderer lineRendere = null;
    [SerializeField] Rigidbody projectile;
    [SerializeField] Transform target;

    [Header("Editor Settings")]
    [SerializeField] bool calc_Trajectory = false;
    [SerializeField] bool calc_Velocity = false;
    [SerializeField] bool calc_SuitableMagAng = false;
    [SerializeField] bool auto_calc = false;

    [Space]
    [SerializeField] bool fire = false;
    float magChange = 0, angChange = 0;
    Vector3 velChange = Vector3.zero;

    private void OnDrawGizmosSelected() 
    {
        if(magChange != launchMagnitude)
        {
            if(calc_SuitableMagAng)
            {
                //call function
                float x = (target.position.x - transform.position.x);
                float y = (target.position.y - transform.position.y);
                float g = -acceleration.y;
                float newAng = Angle_ToReachXY_InGravity_AtMagnitude(x, y, g, launchMagnitude);
                if(float.IsNaN(newAng))
                {
                    launchMagnitude = magChange;
                }
                else
                {
                    magChange = launchMagnitude;
                    launchAngle = newAng;
                    velocity.x = Mathf.Cos(launchAngle * Mathf.Deg2Rad) * launchMagnitude;
                    velocity.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad) * launchMagnitude;
                }
            }
            else
            {
                magChange = launchMagnitude;
                velocity.x = Mathf.Cos(launchAngle * Mathf.Deg2Rad) * launchMagnitude;
                velocity.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad) * launchMagnitude;
            }
        }

        if(angChange != launchAngle)
        {
            if(calc_SuitableMagAng)
            {
                //call function
                float x = (target.position.x - transform.position.x);
                float y = (target.position.y - transform.position.y);
                float g = -acceleration.y;
                float newMag = Magnitude_ToReachXY_InGravity_AtAngle(x, y, g, launchAngle);
                if(float.IsNaN(newMag))
                {
                    launchAngle = angChange;
                }
                else
                {
                    angChange = launchAngle;
                    launchMagnitude = newMag;
                    velocity.x = Mathf.Cos(launchAngle * Mathf.Deg2Rad) * launchMagnitude;
                    velocity.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad) * launchMagnitude;
                }
            }
            else
            {
                angChange = launchAngle;
                velocity.x = Mathf.Cos(launchAngle * Mathf.Deg2Rad) * launchMagnitude;
                velocity.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad) * launchMagnitude;
            }
        }

        if(velChange != velocity)
        {
            velChange = velocity;
            launchMagnitude = velocity.magnitude;
            launchAngle = Vector3.SignedAngle(Vector3.right, velocity, Vector3.forward);
        }

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
        }

        if(fire)
        {
            fire = false;
            projectile.transform.position = transform.position;
            projectile.velocity = velocity + unityAccuracyFix;
        }
    }

    private void OnDrawGizmos() 
    {
        if(auto_calc)
        {
            OnDrawGizmosSelected();
        }    
    }
}
