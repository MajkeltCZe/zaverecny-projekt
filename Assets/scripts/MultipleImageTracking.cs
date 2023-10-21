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
    bool state = true;

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








   
void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;

  

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
     
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
           
                             NameRef.text = "added: " + trackedImage.referenceImage.name;
               state = true;
                




        }           

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
        

  // if(trackedImage.trackingState != TrackingState.Tracking && state == false) {

    //  DeletePrefab(trackedImage);
    //        return;

  //  } 
//else {
            NameRef.text = "Update: " + trackedImage.referenceImage.name;
           UpdateARImage(trackedImage);
               state = false;
 
 //}


        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
          DeletePrefab(trackedImage);
        }
    }
   
   
   private void UpdateARImage(ARTrackedImage trackedImage)
    {
        // Assign and Place Game Object
        AssignGameObject(trackedImage.referenceImage.name,trackedImage.transform.position);
     
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

   
   
   
    

   



    




