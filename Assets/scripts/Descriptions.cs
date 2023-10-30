using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descriptions : MonoBehaviour
{   
     // private static string NameRef;
    public Text text;
    public Button btn;
    public Image bg;
    public Slider slider;
    
    bool change;
     

   public string[] TextToShow;
   
   









public void NewText() {
    if(change == false) {
 //  NameRef = TrackedImageInfoMultipleManager.NameRef;
 //  text.text =  TextsToShow;
     bg.enabled = true;
      change = true;
      slider.gameObject.SetActive(true);


       }

    else {
    text.text = "";
     bg.enabled = false;
        change = false;
       slider.gameObject.SetActive(false);
       btn.gameObject.SetActive(false);
    }   
     
     }
}
