using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;


[RequireComponent(typeof(ARRaycastManager),typeof(ARPlaneManager))]

public class showingObject : MonoBehaviour
{
   [SerializeField] 
   ARRaycastManager RaycastManager; 
   ARPlaneManager m_PlaneManager;

   List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField] 
    GameObject spawnablePrefab;
    

    public Text stav;

 private void Start() {
  
     }


 private void Update()   {

  if (RaycastManager.Raycast(Input.GetTouch(0).position, hits)) { 


    if(Input.GetTouch(0).phase == TouchPhase.Began) { 
      if(hits[0].pose.position == MultipleImageTracking.position) {
      stav.text = "Dlouhýý text";
        }
        } 
    
         }   
}

   }





