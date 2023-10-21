using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickPrefab : MonoBehaviour
{



 int value;

public Text text;

void Start() {
value = 0;

}


public void ClickButtonNext() {
value++;

if(value == 7) {
value =0;

}
text.text = value.ToString();
}


public void ClickButtonPrevious() {
value--;

if(value == -1) {
value = 6;

}
text.text = value.ToString();
}



    
}
