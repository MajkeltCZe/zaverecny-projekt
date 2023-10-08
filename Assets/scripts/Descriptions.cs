using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descriptions : MonoBehaviour
{   
     private static int nameText;
    public Text text;
    public Button btn;
    public Image bg;
    
    bool change;
     

   public string[] TextToShow;
   public string[] NameTextToShow;

    private Dictionary<string, string> TextsToShow = new Dictionary<string, string>();



public void Start() {
bg.enabled = false;
change = false;

  foreach(string txt, string txt2  in TextToShow, NameTextToShow)
        {
            
            TextsToShow.Add(txt,txt2);
        }


}





public void NewText() {
    if(change == false) {
    nameText = TrackedImageInfoMultipleManager.NameText;
    text.text =  TextToShow[nameText];
     bg.enabled = true;
     change = true;
      

       }

    else {
    text.text = "";
     bg.enabled = false;
        change = false;
    }   
     
     }
}
