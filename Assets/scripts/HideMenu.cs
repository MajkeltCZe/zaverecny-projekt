using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMenu : MonoBehaviour
{
[SerializeField]
GameObject[] objects;

public void MenuHiddne() {
foreach(GameObject i in objects) {
i.gameObject.SetActive(false);

}


}


}
