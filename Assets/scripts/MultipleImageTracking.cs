using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageInfoMultipleManager : MonoBehaviour
{






    public static int idx;
   
    public GameObject[] arObjectsToPlace;

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    
    public Button button;
    



void Start() {
HideButton();

}



    void Awake()
    {
            
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        
        foreach(GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
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
             idx = arObjects[trackedImage.name];
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
            
        // Assign and Place Game Object
        AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
        ShowButton();

    }

    void AssignGameObject(string name, Vector3 newPosition)
    {   
        if(arObjectsToPlace != null)
        {
            GameObject goARObject = arObjects[name];
            goARObject.SetActive(true);
            goARObject.transform.position = newPosition;
            
            foreach(GameObject go in arObjects.Values)
            {
                if(go.name != name)
                {
                    go.SetActive(false);
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