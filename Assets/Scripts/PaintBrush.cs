using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    [SerializeField] private GameObject paint;
    [SerializeField] private Transform paintPoint;
    private LineRenderer currentPaint;
    private List<Vector3> currentPositions = new List<Vector3>();

    public void OnActivate()
    {
        currentPaint = Instantiate(paint, paintPoint.position, paintPoint.rotation, null).GetComponent<LineRenderer>();
        currentPositions = new List<Vector3>();
    }

    private void Update() 
    {
        if(currentPaint)
        {
            currentPositions.Add(paintPoint.position);
            currentPaint.positionCount = currentPositions.Count;
            currentPaint.SetPositions(currentPositions.ToArray());
        }
    }

    public void OnDeactivate()
    {
        currentPaint = null;
    }
}
