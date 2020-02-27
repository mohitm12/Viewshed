using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterLevel : MonoBehaviour
{
    public float climbSpeed = 4;
    public InputField inputHeight;
    private bool changeh = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

         if(changeh)
         {
             float h;
             if(inputHeight.text.Length == 0)
             {
                 h = 5f;
             }
             else
             {
                h = float.Parse(inputHeight.text);
             }
                transform.position = new Vector3(512.5f, h, 512.5f); 
            changeh = false;
         }
        else if (Input.GetKey (KeyCode.KeypadPlus))
         {
            transform.position += transform.up * climbSpeed * Time.deltaTime;
            inputHeight.text = (transform.position.y).ToString();

        }
		else if (Input.GetKey (KeyCode.KeypadMinus)) {
            transform.position -= transform.up * climbSpeed * Time.deltaTime;
           inputHeight.text = (transform.position.y ).ToString();

        }
         
         
    }

    public void changeWaterLevel()
    {
        changeh = true;
    }
}
