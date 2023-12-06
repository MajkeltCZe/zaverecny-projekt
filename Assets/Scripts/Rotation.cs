using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{

public Vector3 speed;


void Update() {
transform.Rotate(speed * Time.deltaTime,Space.Self);

}


}