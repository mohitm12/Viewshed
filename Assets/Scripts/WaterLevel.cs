// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WaterLevel : MonoBehaviour
// {
//     public float climbSpeed = 4;
//     public Plane waterPlane;
//     private Vector3 waterSize;
//     public InputField inputLevel;
//     private bool changeh = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         waterSize = waterPlane.size;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKey (KeyCode.KeypadPlus)) {transform.position += transform.up * climbSpeed * Time.deltaTime;}
// 		if (Input.GetKey (KeyCode.KeypadMinus)) {transform.position -= transform.up * climbSpeed * Time.deltaTime;}
//     }

//     public void changeWaterLevel()
//     {

//     }
// }

// public Terrain terrain;
//     private Vector3 terrainSize;
//     public InputField inputHeight;  
    
//     private bool changeh = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         terrainSize = terrain.terrainData.size;
//     }

//     // // Update is called once per frame
//      void Update()
//      {
//          if(changeh)
//          {
//              float h;
//              if(inputHeight.text.Length == 0)
//              {
//                  h = 200f;
//              }
//              else
//              {
//                 h = float.Parse(inputHeight.text);
//              }
//             terrain.terrainData.size = new Vector3(terrainSize.x , h , terrainSize.z);
//             changeh = false;
//          }
         
//     }

//     public void ChangeHeight()
//     {
//         changeh = true;
//     }
