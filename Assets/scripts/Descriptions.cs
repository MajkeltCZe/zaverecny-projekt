using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descriptions : MonoBehaviour
{   
    
    public Text text;
    public Button btn;
    public Image bg;
    
    bool change;
     
public void Start() {
bg.enabled = false;
change = false;

}





public void NewText() {
    if(change == false) {
    text.text = "Paměť RAM se používá hlavně jako operační paměť počítačů, tj. paměť, v níž jsou uloženy běžící programy (včetně operačního systému) a jejich data. Obsah v současnosti používaných polovodičových RAM se po odpojení napájení vymaže (volatilita); proto data, která mají být zachována, je nutné ukládat na disk nebo do flash paměti, která volatilní není. Díky nižší ceně a vyšší kapacitě se používají paměti dynamické, u kterých je informace uchována v podobě elektrického náboje v kondenzátoru, a které je nutné periodicky obnovovat. Aby nedošlo ke smazání paměti uspaného přenosného počítače, musí být paměť nejen napájena, ale musí být v činnosti obvod, který ji pravidelně obnovuje. ";
     bg.enabled = true;
     change = true;
      
       }

    else {
    text.text = "";
     bg.enabled = false;
        change = false;
    }   
     
     }
}
