using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
bool state;
public Text text;
public float targetTime = 60.0f
    void Start()
    {
        state = false;



    }


void Update(){
if(state == true) 
targetTime -= Time.deltaTime;

if (targetTime <= 0.0f)
{
   timerEnded();
}

}

void timerEnded()
{
text.text = state-ToString();

}


}

