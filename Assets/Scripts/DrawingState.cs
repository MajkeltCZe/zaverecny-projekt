using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingState : MonoBehaviour
{
   public GameObject obj;
void OnEnable() => obj.SetActive(true);
    void OnDisable() => obj.SetActive(false);
}
