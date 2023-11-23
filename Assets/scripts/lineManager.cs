using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARDraw : MonoBehaviour
{
    Camera arCamera;

    Vector3 anchor = new Vector3(0,0,0.1f);

    bool anchorUpdate = false; //should anchor update or not

    public GameObject linePrefab; //prefab which genrate the line for user

    LineRenderer lineRenderer; //LineRenderer which connects and generate line
public static bool turn = false;

public Text stav;
    public List<LineRenderer> lineList = new List<LineRenderer>(); //List of lines drawn

    public Transform linePool; //parent object
    
    public bool startLine; //already started line or not
    public bool use; //code is in use or not

	bool moving = false;
	public	GameObject go;
    void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if(!turn) ClearScreen();
if(turn) {
 if (use)
        {
            if (startLine)
            {   
                UpdateAnchor();
                DrawLinewContinue();
            }
        }


		if(Input.touchCount == 1)
		{	
			// touch on screen
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit = new RaycastHit();
				moving = Physics.Raycast (ray, out hit);
			//	if(moving)
			//	{
					//go = hit.transform.gameObject;
                    //stav.text = "HIT";
                   // StartDrawLine();
			//	}
        StartDrawLine();
			}
			// release touch/dragging
			if((Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) && go != null)
			{
				moving = false;
				//stav.text = "NENÍ HIT";
                StopDrawLine();
			}
}
    }
    }

    void UpdateAnchor()
    {   
        if(anchorUpdate)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 0.3f; //offset
            anchor = arCamera.ScreenToWorldPoint(temp);
        }
    }


    public void MakeLineRenderer()
    {
        GameObject tempLine = Instantiate(linePrefab);
        tempLine.transform.SetParent(linePool);
        tempLine.transform.position = Vector3.zero;
        tempLine.transform.localScale = new Vector3(1, 1, 1);
        
        anchorUpdate = true;
        UpdateAnchor();

        lineRenderer = tempLine.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, anchor);

        startLine = true;
        lineList.Add(lineRenderer);
    }
    
    
    public void DrawLinewContinue()
    {
        lineRenderer.positionCount = lineRenderer.positionCount + 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, anchor);
    }

    //to start drawing line
    public void StartDrawLine()
    {
                    use = true;

        
    if(!startLine) MakeLineRenderer();
       
    }

    //to End the line which user started drawing
    public void StopDrawLine()
    {
         use = false;
        startLine = false;
        lineRenderer = null;
        
        anchorUpdate = false;
    }

    //To Undo Last Drawn Line
    public void Undo()
    {
        LineRenderer undo = lineList[lineList.Count-1];
        Destroy(undo.gameObject);
        lineList.RemoveAt(lineList.Count - 1);
    }

    //To clear all the lines
    public void ClearScreen()
    {
        foreach (LineRenderer item in lineList)
        {
            Destroy(item.gameObject);
        }
        lineList.Clear();
    }

    
}

