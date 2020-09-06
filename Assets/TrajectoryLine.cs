using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=Xu0urrCBSpw&t=45s thanks for Tyler Potts
[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer lr;
    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }
    private void Start() {
        EndLine();
    }
    public void RenderLine(Vector3 startPoint, Vector3 endPoint) {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);
    }

    public void EndLine() {
        lr.positionCount = 0;
    }
}
