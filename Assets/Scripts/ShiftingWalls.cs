using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingWalls : MonoBehaviour
{
    public float speed = 2f;
    public GameObject targetPoint1;
    public GameObject targetPoint2;
    private bool moveToPoint1 = true;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPoint1.transform.position, step);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 10);

        if (moveToPoint1 == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint1.transform.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint2.transform.position, step);
        }

        if (this.transform.position == targetPoint1.transform.position)
        {
            moveToPoint1 = false;
        }
        if (this.transform.position == targetPoint2.transform.position)
        {
            moveToPoint1 = true;
        }
    }
}
