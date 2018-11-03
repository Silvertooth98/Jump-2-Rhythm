using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    public GameObject crab;
    public float moveSpeed = 1.0f;
    Transform crabTransform;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = crab.transform.position;
        endPos = new Vector3 (crab.transform.position.x - 3, crab.transform.position.y, crab.transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * moveSpeed, 1));
    }

    //Vector3 pointA = new Vector3(0, 0, 0);
    //Vector3 pointB = new Vector3(1, 1, 1);
    //void Update()
    //{
    //    transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    //}
}
