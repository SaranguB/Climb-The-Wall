using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;

    public float speed = 5f;
    private float distance = 1f;
    Vector2 target;
    public float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        target = Pos();
        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);
        distance = (target - (Vector2)platform.position).magnitude;
        if (distance <= 0.1f)
        {
            direction *= -1;
        }

    }


    Vector2 Pos()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }
    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.position, startPoint.position);
            Gizmos.DrawLine(platform.position, endPoint.position);
        }
    }
}

