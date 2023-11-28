using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class visibleObject : MonoBehaviour
{


 // public Text test;
  int i =0;
    public GameObject go;
  bool hide = false;  
Renderer m_Renderer;
    void Start() => m_Renderer = GetComponent<Renderer>();


    void Update()
    {
        if (m_Renderer.isVisible)   {
        //   test.text = "Object is visible";
            i++;
           if(i==10) {
            hide = true;
            }

            
        }
        else {
            if(hide) {
          //   test.text = "Object is not visible";
            go.SetActive(false);
           i = 0;
           hide = false;
            }
    }
}
}

