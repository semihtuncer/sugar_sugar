using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lr;
    public EdgeCollider2D edgeCollider;

    public List<Vector2> mousePos;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tempMousePos, mousePos[mousePos.Count - 1]) > 0.1f)
            {
                UpdateLine(tempMousePos);
            }
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lr = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        mousePos.Clear();
        mousePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lr.SetPosition(0, mousePos[0]);
        lr.SetPosition(1, mousePos[1]);
        edgeCollider.points = mousePos.ToArray();
    }
    void UpdateLine(Vector2 newMousePos)
    {
        mousePos.Add(newMousePos);
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, newMousePos);
        edgeCollider.points = mousePos.ToArray();
    }
}
