using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
   public void Play() {
 SceneManager.LoadScene("AR");
   }

public void Quit() {
Application.Quit();

}

}
