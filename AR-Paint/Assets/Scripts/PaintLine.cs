using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class PaintLine : MonoBehaviour
{
    [SerializeField]
    private GameObject linePrefab;

    [SerializeField]
    private GameObject currentLine;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private EdgeCollider2D edgeCollider;

    [SerializeField]
    private List<Vector2> fingerPositions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(tempFingerPosition, fingerPositions[fingerPositions.Count - 1]) > .1f)
            {
                UpdateLine(tempFingerPosition);
            }
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);

        lineRenderer = currentLine.GetComponent<LineRenderer>();

        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

        fingerPositions.Clear();

        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);

        edgeCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPosition)
    {
        fingerPositions.Add(newFingerPosition);

        lineRenderer.positionCount++;

        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPosition);

        edgeCollider.points = fingerPositions.ToArray();
    }
}
