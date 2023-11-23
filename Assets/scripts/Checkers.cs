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
string turn;

private List<Transform> blackSquares = new List<Transform>();
private List<Transform> redPieces = new List<Transform>();
private List<Transform> blackPieces = new List<Transform>();


private string[] rules = {"1", "1", "1", "1", "1", "1", "1","1","1","1"};

void Awake() {
turn = "red";
Lists();
}

void Lists() {
        for(int i = 0; i < board.transform.childCount;i++) {
        if(board.transform.GetChild(i).name.Contains("blackBoard"))  blackSquares.Add(board.transform.GetChild(i));
  if(board.transform.GetChild(i).name.Contains("redPiece")) redPieces.Add(board.transform.GetChild(i));
    if(board.transform.GetChild(i).name.Contains("blackPiece")) blackPieces.Add(board.transform.GetChild(i));
        }
}

public void getPosition() {
for(int i = 0; i <blackSquares.Count;i++) {
        if(blackSquares[i].transform.position == piece.transform.position) nowPosPlace = blackSquares[i].name;
        }
}
bool CheckSameCollision(List<Transform> list) {       
for(int i = 0; i <list.Count;i++) {
        if(list[i].transform.position == board.transform.Find(positionName).transform.position) {
                return false;
        }
        }
return true;
}
bool CheckCollision(List<Transform> list, string checkPosition) {
for(int i = 0;i < list.Count;i++) {
          if(list[i].transform.position == board.transform.Find(checkPosition).transform.position) {  
                if(list[i].transform.position != board.transform.Find(positionName).transform.position) {
                   list[i].gameObject.SetActive(false);  
                   list[i].transform.position = new Vector3(0, -10, 5);
                   list.Remove(list[i]);   
                        return true;
}
}
}
return false;
}
 int toInt(char c) {
   return c - '0';
}
bool MoveRules(string piece) {
if(piece.Contains("redPiece")) {
         if(toInt(nowPosPlace[0]) % 2 == 0 || (toInt(nowPosPlace[0]) == 0)) {
                  if(rules[3] == positionName) {
               if(CheckCollision(blackPieces,rules[1])) return true;
             }  
               else  if(rules[4] == positionName) {
               if(CheckCollision(blackPieces,rules[0])) return true;
             }    
              else  if( rules[0]== positionName || rules[1] == positionName)  return true;
        }
        else {
        if(rules[3] == positionName) {
               if(CheckCollision(blackPieces,rules[0])) return true;
             }
         if(rules[4] == positionName) {
                if(CheckCollision(blackPieces,rules[2])) return true;
             }
                if( rules[0]== positionName || rules[2] == positionName) return true;
        }
return false;
}
if(piece.Contains("blackPiece")) {
        if(toInt(nowPosPlace[0]) % 2 == 0) {
                    if(rules[9] == positionName) {
               if(CheckCollision(redPieces,rules[5])) return true;
             }  
                 if(rules[8] == positionName) {
               if(CheckCollision(redPieces,rules[6])) return true;
             }
                if( rules[5]== positionName || rules[6] == positionName)  return true;
        }
        else {
        if(rules[9] == positionName) {
               if(CheckCollision(redPieces,rules[7])) return true;
             }  
        if(rules[8] == positionName) {
               if(CheckCollision(redPieces,rules[5])) return true;
             }
                if(rules[5] == positionName || rules[7] == positionName) return true;
        }
return false;
}
return false;
}


public void Restart() {
         for(int i = 0; i < board.transform.childCount;i++) {
        board.transform.GetChild(i).gameObject.SetActive(false);
        board.transform.GetChild(i).gameObject.SetActive(true);
         Lists();
         turn = "red";
         
         }
}

void setRules() {
//redPieces
rules[0] = (toInt(nowPosPlace[0]) + 1).ToString() + "blackBoard" + (nowPosPlace[nowPosPlace.Length - 1]);
rules[1] = (toInt(nowPosPlace[0]) + 1).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) - 1).ToString();
rules[2] = (toInt(nowPosPlace[0]) + 1).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) + 1).ToString();

rules[3] = (toInt(nowPosPlace[0]) + 2).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) - 1).ToString();
rules[4] = (toInt(nowPosPlace[0]) + 2).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) + 1).ToString();

// blackPieces rules
rules[5] = (toInt(nowPosPlace[0]) - 1).ToString() + "blackBoard" + (nowPosPlace[nowPosPlace.Length - 1]);
rules[6] = (toInt(nowPosPlace[0]) - 1).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) - 1).ToString();
rules[7] = (toInt(nowPosPlace[0]) - 1).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) + 1).ToString();

rules[8] = (toInt(nowPosPlace[0]) - 2).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) - 1).ToString();
rules[9] = (toInt(nowPosPlace[0]) - 2).ToString() + "blackBoard" + (toInt(nowPosPlace[nowPosPlace.Length - 1]) + 1).ToString();       
}




public void Board() {
        piece = board.transform.Find(nameOf);
        if (piece != null)  {

setRules();
if(MoveRules(nameOf)) {
        if(nameOf.Contains("redPiece") && turn == "red") {
         if (CheckSameCollision(redPieces)) {
         piece.transform.position = board.transform.Find(positionName).transform.position;
        turn = "black";
         
         }
      }
         if(nameOf.Contains("blackPiece") && turn == "black") {
   if (CheckSameCollision(blackPieces)) {
         piece.transform.position = board.transform.Find(positionName).transform.position;
      turn = "red";
      }
         }
 }
}
}
   }





 





 


