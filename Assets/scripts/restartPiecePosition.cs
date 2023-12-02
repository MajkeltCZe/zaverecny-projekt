using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPiecePosition : MonoBehaviour
{

    Vector3 startPos;

void Awake() {
 startPos = transform.position;

}

void OnEnable() {
     transform.position = startPos;
}
    
}
