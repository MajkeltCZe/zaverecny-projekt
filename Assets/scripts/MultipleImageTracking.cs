using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

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

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

   

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
                
            UpdateARImage(trackedImage);
            
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            
          trackedImage.name = name;
        
            
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        // Display the name of the tracked image in the canvas
            NameRef.text = trackedImage.referenceImage.name;
        // Assign and Place Game Object
        AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
        }
      //  ShowButton();

    

    void AssignGameObject(string name, Vector3 newPosition)
    {   
        if(arObjectsToPlace != null)
        {
        
            arObjects[name].SetActive(true);
            arObjects[name].transform.position = newPosition;
            
            foreach(GameObject i in arObjects.Values)
            {
                if(i.name != name)
                {
                    i.SetActive(false);
                }
            } 
        }
    }


 public void HideButton() {
    button.gameObject.SetActive(false);
}

public void ShowButton() {
    button.gameObject.SetActive(true);
}

 }