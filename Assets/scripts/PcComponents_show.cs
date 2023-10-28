using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcComponents_show : MonoBehaviour
{

[SerializeField]
GameObject[] MenuObjects;

[SerializeField] 
private string[] TextToShow;

[SerializeField] 
public Text text;

private string name = "cat";
[SerializeField] 
private GameObject parent;
   
 
void Start() {
HideMenu();

}



public void ShowObjects() {

foreach(GameObject i in MenuObjects) {
i.gameObject.SetActive(true);

}

for(int i = 0; i < parent.transform.childCount;i++) {
    if(parent.transform.GetChild(i).name == name) {
           parent.gameObject.SetActive(true);
           text.text = TextToShow[i];
         parent.transform.GetChild(i).gameObject.SetActive(true);
    }
    else parent.transform.GetChild(i).gameObject.SetActive(false);
}
 }



public void HideMenu() {
foreach(GameObject i in MenuObjects) {
i.gameObject.SetActive(false);

}
}
} 