using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectValues : MonoBehaviour
{
    
public void AssignName() {
PcComponents_show.nameID = name.ToString();
}



public void AssignPieceName() {
Checkers.nameOf = name.ToString();
}

public void AssignPiecePlace() {
Checkers.position = transform.position;
}

}


