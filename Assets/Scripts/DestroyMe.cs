using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{   
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Tower" || col.gameObject.tag == "Target")
        {
            // var exp = col.gameObject.GetComponent<ParticleSystem>();
            // exp.Play();
            Destroy(col.gameObject);
        }
    }
}
