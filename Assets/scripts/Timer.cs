using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TimerTest : MonoBehaviour
{

bool state;

public Text test;
    public void Testing() {
        state = true;
        test.text = "přidáno";
   Timer.Register(5f, () => ChangeState());
 
 }


void ChangeState() {
state = false;

}


public void ChangeText() {
   if(state == false) test.text = "LZE Odebrat";
state = true;

}





}
