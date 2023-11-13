using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkers : MonoBehaviour
{
 

    public GameObject board;
    private Transform piece;
    string nameOf;

public Vector3 GetPosition() {
return transform.position;
}

public void GetName() {
 nameOf = name.ToString();

}







void Board() {


        piece = board.transform.Find(nameOf);

        if (piece != null)     {

    piece.transform.position = GetPosition();

        }



}





}
