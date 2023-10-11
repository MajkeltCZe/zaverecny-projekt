using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;


public class setState: MonoBehaviour
{
public GameObject prefab;
public bool state;



    // Start is called before the first frame update
    void Start()
    {
        prefab.SetActive(state);

    }





}
