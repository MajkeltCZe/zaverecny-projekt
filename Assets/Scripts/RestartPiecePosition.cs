using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPiecePosition : MonoBehaviour
{

 Vector3 startPos;


void OnBecamevisible() {
        startPos =  gameObject.transform.position;
}


public void RestartPosition() {
        gameObject.transform.position = startPos;
  
}

    
}
