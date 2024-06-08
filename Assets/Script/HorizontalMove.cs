using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 6f;
    private float distance = 1f;
    private float direction = 1;

    Vector2 target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = TargetPos();
        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);

        distance = (target - (Vector2)platform.position).magnitude;
        if (distance <= 0.1f)
        {
            direction *= -1;
        }


    }
    Vector2 TargetPos()
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
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);

        }
    }
}
