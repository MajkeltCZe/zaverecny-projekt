using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickPrefab : MonoBehaviour
{


[HideInInspector] 
public static int value;



void Start() {
value = 0;

}

public void ClickButtonNext() {
value++;


if(value == 4) {
value =0;

}
}


public void ClickButtonPrevious() {
value--;

if(value == -1) {
value = 3;

}
}




    
}
