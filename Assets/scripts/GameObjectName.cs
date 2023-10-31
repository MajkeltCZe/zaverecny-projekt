using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectName : MonoBehaviour
{

public Text txt;
public GameObject g;

   // or you can do this also 
   




public void AssignName() {
PcComponents_show.nameID = g.name.ToString();
txt.text = PcComponents_show.nameID;
}
}
