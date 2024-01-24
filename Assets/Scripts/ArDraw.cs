using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARDraw: MonoBehaviour {
  Camera arCamera;

  Vector3 anchor = new Vector3(0, 0, 0.1f);

  bool anchorUpdate = false;

  public GameObject linePrefab;

  LineRenderer lineRenderer;
  public List < LineRenderer > lineList = new List < LineRenderer > (); //List of lines drawn

  public Transform linePool; //parent object

  bool startLine; //already started line or not
  bool use; //code is in use or not

  public Text stav;

  void Start() {
    arCamera = GameObject.Find("AR Camera").GetComponent <Camera>();
  }

  void Update() {
    if (use) {
      if (startLine) {
        UpdateAnchor();
        DrawLinewContinue();
      }
    }

    {
      // touch on screen
      if (Input.GetTouch(0).phase == TouchPhase.Began && !IsUIOver()) {

        StartDrawLine();
      }

      // release touch/dragging
      if ((Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)) {
        StopDrawLine();
      }
    }
  }

  private bool IsUIOver() {
    return EventSystem.current.IsPointerOverGameObject();
  }

  void UpdateAnchor() {
    if (anchorUpdate) {
      Vector3 temp = Input.GetTouch(0).position;
      temp.z = 0.3f; //offset
      anchor = arCamera.ScreenToWorldPoint(temp);
    }
  }

  public void MakeLineRenderer() {
    GameObject tempLine = Instantiate(linePrefab);
    tempLine.transform.SetParent(linePool);
    tempLine.transform.position = Vector3.zero;
    tempLine.transform.localScale = new Vector3(1, 1, 1);

    anchorUpdate = true;
    UpdateAnchor();

    lineRenderer = tempLine.GetComponent < LineRenderer > ();
    lineRenderer.positionCount = 1;
    lineRenderer.SetPosition(0, anchor);

    startLine = true;
    lineList.Add(lineRenderer);
  }

  void DrawLinewContinue() {
    lineRenderer.positionCount = lineRenderer.positionCount + 1;
    lineRenderer.SetPosition(lineRenderer.positionCount - 1, anchor);
  }

  public void StartDrawLine() {
    use = true;

    if (!startLine) MakeLineRenderer();

  }

  public void StopDrawLine() {
    use = false;
    startLine = false;
    lineRenderer = null;

    anchorUpdate = false;
  }

  public void ClearScreen() {
    foreach(LineRenderer item in lineList) {
      Destroy(item.gameObject);
    }
    lineList.Clear();
  }

}













