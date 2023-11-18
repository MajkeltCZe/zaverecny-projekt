using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Test : MonoBehaviour
{
   public Text test;



public void HoverEnter() {
test.text = "hoverEnter";

}

public void HoverExit() {
test.text = "hoverExit";

}
public void SelectEnter() {
test.text = "SelectEnter";

}
public void SelectExit() {
test.text = "SelectExit";

}




}
