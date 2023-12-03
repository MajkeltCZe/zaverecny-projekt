using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VisibleObject : MonoBehaviour
{


  int i =0;
    public GameObject go;
  bool hide = false;  
Renderer m_Renderer;
    void Start() => m_Renderer = GetComponent<Renderer>();


    void Update()
    {
       MultipleImagesTracking.state = hide;

        if (m_Renderer.isVisible)   {
            i++;
           if(i==20) {
            hide = true;
            }

            
        }
        else {

            if(hide) {
            go.SetActive(false);
           i = 0;
           hide = false;
            }
    }
}
}


