using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotation : MonoBehaviour
{
public void RotateMyObject(GameObject objectToRotate)
{
    float sliderValue = GetComponent<Slider>().value;
    objectToRotate.transform.rotation = Quaternion.Euler(sliderValue * 360, 0, 90);
}
}


// Resources.Load