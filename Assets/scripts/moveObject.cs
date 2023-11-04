using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    // Start is called before the first frame update
  public Vector3 coordinates;
   public void Move() {
   transform.position += coordinates;

}
}