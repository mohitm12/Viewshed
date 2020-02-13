using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToViewshed : MonoBehaviour
{
   public void changeScene()
   {
       SceneManager.LoadScene("Viewshed");
   }
}
