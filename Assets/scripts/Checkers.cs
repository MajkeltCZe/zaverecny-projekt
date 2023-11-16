using System.Collections;
using System.Collections.Generic;
 using System;
using UnityEngine;
using UnityEngine.UI;

public class Checkers : MonoBehaviour
{
 
public Text test;
    public GameObject board;
    private Transform piece;
   public static string nameOf;
public static string positionName;

string nowPosPlace;
int value;

private List<Transform> blackSquares = new List<Transform>();
private List<Transform> redPieces = new List<Transform>();
private List<Transform> blackPieces = new List<Transform>();


void Awake() {
for(int i = 0; i < board.transform.childCount;i++) {
        if(board.transform.GetChild(i).name.Contains("blackBoard")) {  
           blackSquares.Add(board.transform.GetChild(i));
    }
  if(board.transform.GetChild(i).name.Contains("red")) {  
           redPieces.Add(board.transform.GetChild(i));
    }
    if(board.transform.GetChild(i).name.Contains("black")) {  
           blackPieces.Add(board.transform.GetChild(i));
    }
        }


}



public void getPosition() {
        test.text = nameOf; 
for(int i = 0; i <blackSquares.Count;i++) {
        if(blackSquares[i].transform.position == piece.transform.position) {  
           nowPosPlace = blackSquares[i].name;
    }
        }

}





 int toInt(char c) {
   return c - '0';
}

public void Board() {
        piece = board.transform.Find(nameOf);
        test.text = nameOf; 

        if (piece != null)     {
                 getPosition();      



//for Red piece

if(toInt(nowPosPlace[0]) % 2 == 0 || (toInt(nowPosPlace[0]) == 0)) {

        if(((toInt(nowPosPlace[0]) +  1).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) - 1).ToString() == positionName) || 
        ((toInt(nowPosPlace[0]) +  1).ToString() + "blackBoard" + (nowPosPlace[nowPosPlace.Length - 1]) == positionName)) {

        piece.transform.position = board.transform.Find(positionName).transform.position;
   }
}
else {
          if(((toInt(nowPosPlace[0]) +  1).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) + 1).ToString() == positionName) || 
        ((toInt(nowPosPlace[0]) +  1).ToString() + "blackBoard" + (nowPosPlace[nowPosPlace.Length - 1]) == positionName)) {

        piece.transform.position = board.transform.Find(positionName).transform.position;
   }


}




 
 
 




}
}


 


}