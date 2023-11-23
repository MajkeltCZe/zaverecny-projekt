using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]


public class MultipleImageTracking : MonoBehaviour
{
    //public GameObject pcPlaced;

    public Text NameRef;

    public GameObject[] arObjectsToPlace;

    public GameObject[] menus;
   
    private ARTrackedImageManager m_TrackedImageManager;
    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    bool state = true;
    private static int value = 0;
    int score =0;
    void Awake()
    {

        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            newARObject.SetActive(false);
            arObjects.Add(arObject.name, newARObject);
        }

        foreach(GameObject go in menus) {
            go.SetActive(false);
        }
      
        
    }

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {

                            score++;        

                        NameRef.text = "Byl přidán obrázek: " + trackedImage.referenceImage.name;
                            
            name = trackedImage.referenceImage.name;
          //  state = false;
          
                            UpdateARImage(name, trackedImage);
          ShowInteractableUI(name);

        }
 foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
           NameRef.text = "Vyčkej na zobrazení předmětu "  + trackedImage.referenceImage.name;

if(trackedImage.trackingState != TrackingState.Tracking && state == false) {
    NameRef.text = "deleted:" + trackedImage.referenceImage.name;
      DeletePrefab();
          state = true;
          return;
            
  }
  else {
                if (trackedImage.referenceImage.name == "mechatronika")  {
                    value = OnClickPrefab.value;
                    UpdateARImage(value.ToString(), trackedImage);
                    ARDraw.turn = false;

                    
                   
                 }
                else if(trackedImage.referenceImage.name == "drawingCanvas") {
                 NameRef.text = "Můžeš kreslit na mobil!";
                   ARDraw.turn = true;
                   DeletePrefab();
                    
                 
                 }
                
                
                else {
                name = trackedImage.referenceImage.name;
                UpdateARImage(name, trackedImage);
                                ARDraw.turn = false;

                }

                ShowInteractableUI(name);
        //  state = false;

        }
        }
      //  foreach (ARTrackedImage trackedImage in eventArgs.removed) DeletePrefab(trackedImage);    
    }


    private void UpdateARImage(string name, ARTrackedImage trackedImage)
    {
        AssignGameObject(name, trackedImage.transform.position);
    }



    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (arObjectsToPlace != null)
        {
            GameObject prefab = arObjects[name];
            prefab.transform.position = newPosition;
            prefab.SetActive(true);
            foreach (GameObject i in arObjects.Values)
            {
                if (i.name != name)
                {
                    i.SetActive(false);
                }
            }

        }
    }

    void DeletePrefab()  {
        //NameRef.text = "object was deleted";
        HideInteractableUI();
         foreach (GameObject i in arObjects.Values)
            {
                    i.SetActive(false);
                //    arObjects.Values["video"]
            }
            
        }
    

    void ShowInteractableUI(string name) {
        foreach(GameObject i in menus) {
            if(i.name == name) {
                i.SetActive(true);
            }
            else i.SetActive(false);
        }

    }
    
        void HideInteractableUI() {
        foreach(GameObject i in menus) {
           i.SetActive(false);
        }

    }




    void ChangeState(){
        state = false;
    }

}















