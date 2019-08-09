using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformBarriers : MonoBehaviour
{
    public float xLength;
    public float yLength;
    public float zLength;
    public float linearSpeed;
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
        if(spinCCW && spinCCW)
        {
            spinCCW = false;
        }
        offset = transform.localPosition;
       //angle = 0f;
    }

    void Update()
    {
        TransAngle += Time.deltaTime * linearSpeed;

        float xpos = Mathf.Sin(TransAngle) * xLength;
        float ypos = Mathf.Sin(TransAngle) * yLength;
        float zpos = Mathf.Sin(TransAngle) * zLength;

        Vector3 movement = new Vector3(xpos, ypos, zpos);

        float angle = Time.deltaTime * angularSpeed;

        if (spinCCW)
        {
            transform.Rotate(new Vector3(0, angle, 0));
        }
        else if(spinCW)
        {
            transform.Rotate(new Vector3(0, -angle, 0));
        }
        
        
        transform.localPosition = movement + offset;
    }
}
