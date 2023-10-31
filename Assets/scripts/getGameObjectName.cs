using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getGameObjectName : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
public GameObject go;

public void GetName() {

text.text = go.name.ToString();


}

}
