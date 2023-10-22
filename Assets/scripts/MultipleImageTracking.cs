using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]

public class MultipleImageTracking : MonoBehaviour
{
    public Text NameRef;
   
 public GameObject[] arObjectsToPlace;

    public GameObject[] buttons;

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    
    bool state = true;
 public  static  Vector3 positions;
 private static int value;

    void Awake()
    {
       
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        

         foreach(GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            newARObject.SetActive(false);
            arObjects.Add(arObject.name, newARObject);
        } 



 


   }
        
    
void Update() {

 value = OnClickPrefab.value;

}



   
void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;

  

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
           name =  trackedImage.referenceImage.name;
                           //  NameRef.text = "added: " + trackedImage.referenceImage.name;
        UpdateARImage(name,trackedImage);
               state = true;
                


        }           

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
                


  // if(trackedImage.trackingState != TrackingState.Tracking && state == false) {

    //  DeletePrefab(trackedImage);
    //        return;

  //  } 
//else {
 
          if(trackedImage.referenceImage.name == "grafika") {
                     positions =   trackedImage.transform.position;
                         

           }
       

                   //    name =  trackedImage.referenceImage.name;




          //  UpdateARImage(name,trackedImage);

               state = false;
 
 //}


        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
          DeletePrefab(trackedImage);
        }
    }
   
   
 
 private void UpdateARImage(string name,ARTrackedImage trackedImage)
    {
        // Assign and Place Game Object
        AssignGameObject(name,trackedImage.transform.position);
        
        }
    




   void AssignGameObject(string name, Vector3 newPosition)
    {   
        if(arObjectsToPlace != null)
        {
            GameObject prefab = arObjects[name];
           prefab.transform.position = newPosition;
           prefab.SetActive(true);
           foreach(GameObject i in arObjects.Values)
            {
                if(i.name != name)
                {
                    i.SetActive(false);
                }
            } 
        
        }
    }

void DeletePrefab(ARTrackedImage trackedImage) {
               arObjects[trackedImage.referenceImage.name].SetActive(false);
                               NameRef.text = "Deleted: " + trackedImage.referenceImage.name;

           } 
    
    }

   

   
    

   



    




