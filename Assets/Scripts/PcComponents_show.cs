using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcComponents_show : MonoBehaviour
{

public GameObject MenuObjects;

public string[] TextToShow;
public Text check;

[SerializeField] 
public Text text;
public GameObject parent;
public GameObject showImages;

public static string nameID;
 



void Start() {
HideMenu();
}

public void ShowObjects() {
MenuObjects.SetActive(true);
showImages.SetActive(false);


check.text = nameID;
for(int i = 0; i < parent.transform.childCount;i++) {
             parent.gameObject.SetActive(true);

    if(parent.transform.GetChild(i).name == nameID) {
           text.text = TextToShow[i];
         parent.transform.GetChild(i).gameObject.SetActive(true);
    }
    else parent.transform.GetChild(i).gameObject.SetActive(false);
}
 }


public void HideMenu() {
MenuObjects.SetActive(false);
showImages.SetActive(true);
}
} 