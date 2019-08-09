using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehavior : MonoBehaviour
{
    public float xRadius;
    public float yRadius;
    public float speed;
    public float tilt; 

    private float angle;
    private Vector3 Offset;

    void Start()
    {
       // transform.Rotate(Vector3.forward, tilt, Space.Self);
        //transform.localEulerAngles(0f, 0f, tilt);
        //transform.Rotate
        Offset = transform.localPosition;
        angle = 0f;
    }

    // Update is called once per frame
        void Update()
    {
        /*

        Vector3 temp = new Vector3(Mathf.Sin(Time.time * speed) * radius, Mathf.Cos(Time.time * speed) * radius, Mathf.Cos(Time.time * speed));
        Vector3 movement = temp + Offset;

        transform.position = movement;
        */

        Path();
    }

    private void Path()
    {
        //Offset = transform.position;

        angle += Time.deltaTime * speed;

        float xpos = Mathf.Sin(angle) * xRadius + Offset.x;
        float ypos = Mathf.Cos(angle) * yRadius + Offset.y- yRadius;
        float zpos = Mathf.Sin(angle) + Offset.z;
        /*
        xpos = xpos * Mathf.Cos(tilt) - ypos * Mathf.Sin(tilt) + Offset.x;
        ypos = xpos * Mathf.Sin(tilt) + ypos * Mathf.Cos(tilt) + Offset.y;// - yRadius;
        */
        Vector3 movement = new Vector3(xpos, ypos, zpos);

        transform.localPosition = movement;
    }
}
