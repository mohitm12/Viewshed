﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    public Terrain terrain;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround();   
    }

    void OrbitAround()
    {
        transform.RotateAround(terrain.transform.position, Vector3.back, speed * Time.deltaTime);
    }
}
