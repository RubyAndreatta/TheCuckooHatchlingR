using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tentacle : MonoBehaviour
{
    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDirection;
    public float targetDistance;
    public float smoothSpeed;
    public float wiggleSpeed; public float wiggleMagnitude; public Transform wiggleDir;



    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];


    }

    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
        segmentPoses[0] = targetDirection.position;
       
       
        float targetSmoothSpeed = (Vector3.Distance(segmentPoses[1], segmentPoses[0]) > targetDistance) ? 0.001f : 0.1f;

        // Smoothly transition smoothSpeed to the target value
        smoothSpeed = Mathf.Lerp(smoothSpeed, targetSmoothSpeed, Time.deltaTime * 5f);  // The 5f is the speed of transition

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDirection.right * targetDistance, ref segmentV[i], smoothSpeed);
        }

        lineRend.SetPositions(segmentPoses);
    }
}