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
           HideButton(); 
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        
        foreach(GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }



         foreach(GameObject i in arObjects.Values)
            {
                    i.SetActive(false);
            } 
    }


   
void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;

   

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
                 
                  UpdateARImage(trackedImage);
                    NameRef.text = "přídáno";
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {

          trackedImage.name = name;
       
         //   if(trackedImage.trackingState != TrackingState.Tracking) {


               //  DeleteObject();
         //   }
            
           
            UpdateARImage(trackedImage);
             
        }

 

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
           DeleteObject(trackedImage.referenceImage.name);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        // Display the name of the tracked image in the canvas
          //  NameRef.text = trackedImage.referenceImage.name;
            Vector3 position = trackedImage.transform.position;
        // Assign and Place Game Object
        AssignGameObject(trackedImage.referenceImage.name,position);
        
        }
      //  ShowButton();

    




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

void DeleteObject(string name) {
   NameRef.text = "Not Found";
        arObjects[name].SetActive(false);
        //    foreach(GameObject i in arObjects.Values)
          //  {
                //    i.SetActive(false);
                
           // } 
//HideButton();
}




 public void HideButton() {
    button.gameObject.SetActive(false);
}

public void ShowButton() {
    button.gameObject.SetActive(true);
}

 }