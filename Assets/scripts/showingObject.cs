using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using enhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager),typeof(ARPlaneManager))]

public class showingObject : MonoBehaviour
{
   [SerializeField] 
   ARRaycastManager m_RaycastManager; 
   List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField] 
    GameObject spawnablePrefab;
     GameObject spawnedObject;

    

 private void Start() {
   spawnedObject = null;
     }


 private void Update()   {

  if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits)) { 
    if(Input.GetTouch(0).phase == TouchPhase.Began) { 
        SpawnPrefab(m_Hits[0].pose.position); 
        } 
        else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
         { spawnedObject.transform.position = m_Hits[0].pose.position; } 
         if(Input.GetTouch(0).phase == TouchPhase.Ended) { 
            
            spawnedObject = null; 
         } 
         }   
}
public void SpawnPrefab(Vector3 spawnPosition) {
            spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity); 
            }

}
