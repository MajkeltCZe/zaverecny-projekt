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
   public string[] TextToShowName;
   
    private Dictionary<string, string> TextsToShow = new Dictionary<string, string>();



public void Start() {
bg.enabled = false;
change = false;
slider.gameObject.SetActive(false);
//NameRef = "ram";

        for (int i = 0; i < TextToShow.Length;i++) {
        
            TextsToShow.Add(TextToShowName[i], TextToShow[i]);
        }


}





public void NewText() {
    if(change == false) {
 //  NameRef = TrackedImageInfoMultipleManager.NameRef;
 //  text.text =  TextsToShow[NameRef];
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
