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

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    
    public Button button;

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        
      
        
    }



   
void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;

   

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
     
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
                GameObject newARObject  =    Instantiate(trackedImage.referenceImage.name, trackedImage.transform.position, Quaternion.identity);
                             NameRef.text = "added: " + trackedImage.referenceImage.name;
                   
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
        

   // if(trackedImage.trackingState != TrackingState.Tracking) {
         
//DeletePrefab(trackedImage.referenceImage.name);
    //                return;

  //      } 

            NameRef.text = "Update: " + trackedImage.referenceImage.name;
        //    UpdateARImage(trackedImage);

        newARObject.SetActive(true);


        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            trackedImage.name = name;
         //  DeletePrefab(name);
        }
    }
   
   
   private void UpdateARImage(ARTrackedImage trackedImage)
    {
            Vector3 position = trackedImage.transform.position;
        // Assign and Place Game Object
        AssignGameObject(trackedImage.referenceImage.name,position);
     
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

void DeletePrefab(string name) {
               GameObject prefab = arObjects[name];

                     prefab.SetActive(false);
          
           } 
    
    }






   
   
   
    

   



    




