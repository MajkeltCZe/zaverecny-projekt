using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;



public class Test: MonoBehaviour
{
     [SerializeField] 
   ARRaycastManager RaycastManager; 
   ARPlaneManager m_PlaneManager;

   List<ARRaycastHit> hits = new List<ARRaycastHit>();
 public void Move() {

  if (RaycastManager.Raycast(Input.GetTouch(0).position, hits)) { 


    if(Input.GetTouch(0).phase == TouchPhase.Began) { 
     transform.position =   hits[0].pose.position; 
       
        } 
    
         }   
}








   // transform.position = new Vector3(0.1f, 0, 0);

}
