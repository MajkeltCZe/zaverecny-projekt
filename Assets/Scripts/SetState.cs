using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;


public class SetState : MonoBehaviour
{
public GameObject prefab;
public bool stateStart;



    // Start is called before the first frame update
    void Start()
    {
        prefab.SetActive(stateStart);

    }


public void HideObject() {
    prefab.SetActive(false);
}
public void ShowObject() {
    prefab.SetActive(true);
}


}
