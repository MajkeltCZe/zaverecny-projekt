using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public GameObject go;
        void Start()
    {
        
    }

  public void Move() {
go.transform.position += new Vector3(0, 0.1f, 0);


   }


}
