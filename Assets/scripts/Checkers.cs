using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkers : MonoBehaviour
{
 
public Text test;
    public GameObject board;
    private Transform piece;
   public static string nameOf;
public static Vector3 position;




public void Board() {


        piece = board.transform.Find("red");

        if (piece != null)     {

test.text= nameOf + " neco: " + position.ToString();
piece.transform.position = position;

        }



}





}
