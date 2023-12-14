using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public string[] animationNames;

            Animator m_Animator;
            bool state;

void Start() {
    state = true;
    m_Animator = gameObject.GetComponent<Animator>();
}

  public void OnClickAnimation() {
    if(state) {
    m_Animator.SetTrigger(animationNames[0]);
            state = false;

    }
    else {
    m_Animator.SetTrigger(animationNames[1]);
        state = true;
    }
  }
  
}
