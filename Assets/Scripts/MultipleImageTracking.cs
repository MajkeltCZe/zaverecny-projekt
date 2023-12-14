using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class MultipleImagesTracking : MonoBehaviour
{
    public Text text;
    public Text scoreText;
    public GameObject[] arObjects;
    public GameObject[] menuObjects;
    public GameObject imageMenu;
    public static bool state;
    int score = 0;
        private static int value = 0;
        int timeOut;


private ARTrackedImageManager m_TrackedImageManager;
private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

  void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        setPrefabs();
        HideMenu();
    
    }


void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;


void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs) {
    foreach (var trackedImage in eventArgs.added) {
        text.text = "Byl přidán obrázek, vyčkej na zobrazení předmětu";
             UpdateARImage(trackedImage.referenceImage.name,trackedImage);
             score++;
               scoreText.text = score + "/" + 5;

    }
        foreach (var trackedImage in eventArgs.updated) {
       if(trackedImage.trackingState != TrackingState.Tracking) {
         text.text = "Ztratil si dobrou viditelnost obrázku: ";
         

        timeOut = 0;
     //   timeOut++;
        if(timeOut == 500 && (trackedImage.referenceImage.name == "drawingCanvas" || trackedImage.referenceImage.name == "mechatronika")) {
                    HideInteractible(trackedImage.referenceImage.name);
                    timeOut = 0;

        }
        
       else if(state) {
        HideInteractible(trackedImage.referenceImage.name);
            imageMenu.SetActive(true);

        text.text = "";
        if(score == 5) {
            text.text = "Našel si všechny obrázky!";
        }
       }
       }
       
       else {
        text.text = trackedImage.referenceImage.name;
        ShowInteractible(trackedImage.referenceImage.name);
       
         if (trackedImage.referenceImage.name == "mechatronika")  {
                    value = OnClickPrefab.value;
                    UpdateARImage(value.ToString(), trackedImage);
       }
        else {
        UpdateARImage(trackedImage.referenceImage.name,trackedImage);
       }
    imageMenu.SetActive(false);
    }

}
}

void HideMenu() {
    foreach(GameObject go in menuObjects) go.SetActive(false);
}


void HideInteractible(string name) {
foreach(GameObject go in menuObjects) {
     if(go.name == name) {
        go.SetActive(false);
    }
}

}


void ShowInteractible( string name) {
foreach(GameObject go in menuObjects) {
    if(go.name == name) {
        go.SetActive(true);
    }
    else {
        go.SetActive(false);
    }
}

}

    private void UpdateARImage(string name, ARTrackedImage trackedImage)
    {
        AssignGameObject(name, trackedImage.transform.position);
    }



    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (prefabs != null)
        {
            GameObject prefab = prefabs[name];
            prefab.transform.position = newPosition;
            prefab.SetActive(true);
            foreach (GameObject i in prefabs.Values)
            {
                if (i.name != name) i.SetActive(false);
            }

        }
    }


void setPrefabs() {
      foreach (GameObject arObject in arObjects) {
        GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            newARObject.SetActive(false);
            prefabs.Add(arObject.name, newARObject);
      }
      }

}














