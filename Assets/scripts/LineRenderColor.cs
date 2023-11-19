using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererColor : MonoBehaviour
{
public LineRenderer lineRenderer;
public void ColorLine() {
lineRenderer.SetColors( this.GetComponent<Button>().colors.normalColor, this.GetComponent<Button>().colors.normalColor);
}
}
