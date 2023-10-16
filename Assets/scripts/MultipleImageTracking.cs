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
                                    System.Timers.Timer timer = new System.Timers.Timer(interval: 5000);

    public Button button;
    bool AddedState = false;

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
                
                             NameRef.text = "added: " + trackedImage.referenceImage.name;
                                timer.Enabled = true;


                   
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
          trackedImage.name = name;
        

      if(trackedImage.trackingState != TrackingState.Tracking && AddedState == false) {
                 NameRef.text = "Image not Found ";


        }
    }

  
    }


 private static void OnTimerElapsed(Object source, System.Timers.ElapsedEventArgs e)
    {

    }


}




   
   
   
    

   



    




