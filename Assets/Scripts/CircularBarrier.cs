using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularBarrier : MonoBehaviour
{
    public float xLength;
    public float yLength;
    public float zLength;
    public float Speed;
    public bool spinCCW;
    public bool spinCW;
    [Range(0.0f, Mathf.PI)]
    public float angularSpeed;


    private Rigidbody rb;
    private Vector3 offset;
    //private float angle;
    private float TransAngle;

    void Start()
    {
        if (spinCW && spinCCW)
        {
            spinCW = false;
        }
        offset = transform.localPosition;
        //angle = 0f;
    }

    void Update()
    {
        TransAngle += Time.deltaTime * Speed;

        float xpos = Mathf.Sin(TransAngle) * xLength;
        float ypos = Mathf.Cos(TransAngle) * yLength;
        float zpos = Mathf.Cos(TransAngle) * zLength;

        Vector3 movement = new Vector3(xpos, ypos, zpos);

        float angle = Time.deltaTime * (angularSpeed * 180.0f / Mathf.PI);

        if (spinCCW)
        {
            transform.Rotate(new Vector3(0, angle, 0), Space.World);
        }
        else if (spinCW)
        {
            transform.Rotate(new Vector3(0, -angle, 0), Space.World);
        }


        transform.localPosition = movement + offset;
        //transform.position = movement + offset;
    }
}
