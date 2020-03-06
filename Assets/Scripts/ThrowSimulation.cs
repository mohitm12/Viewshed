using UnityEngine;
using System.Collections;
 
public class ThrowSimulation : MonoBehaviour
{
    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    public LineRenderer lineRenderer;
    public Transform Projectile; 
    public GameObject source;     
    private Transform myTransform;
   
    void Awake()
    {
        myTransform = transform;      
    }
 
    void Start()
    {          
        
    }
 
    public void startProjectile()
    {
        
        StartCoroutine(SimulateProjectile());
        
    }
 
    IEnumerator SimulateProjectile()
    {
        
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);
       
        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);
       
        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);
 
        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
 
        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
 
        // Calculate flight time.
        float flightDuration = target_Distance / Vx;
        Debug.Log(flightDuration);
            // Rotate projectile to face the target.
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);
       source.SetActive(false);
        float elapse_time = 0;
        //int i = int.Parse(flightDuration) * 20;
        //int i;
        //Projectile.gameObject.SetActive(true);
        while (elapse_time < flightDuration)
        {
            //i = 0 ;
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
           // lineRenderer.SetPosition(i, new Vector3(Vx * Time.deltaTime,(Vy - (gravity * elapse_time)) * Time.deltaTime,0f));
            elapse_time += Time.deltaTime;
            //lineRenderer.SetPosition(, Projectile.position);
            yield return null;
        //    i++;
        }
        //Projectile.gameObject.SetActive(false);
                source.SetActive(true);
                Projectile.position = source.transform.position;

    }  
}