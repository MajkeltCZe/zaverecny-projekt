using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectName : MonoBehaviour
{
PcComponents_show neco;
public Text txt;
public GameObject g;
public void AssignName() {
txt.text = neco.nameID;

}
}
