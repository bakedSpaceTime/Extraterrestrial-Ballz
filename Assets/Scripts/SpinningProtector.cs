using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningProtector : MonoBehaviour
{
    public GameObject PiecePrefab;
    public Transform parent;

    [Header("World Euler Spin Axis")]
    public float xEAxis;
    public float yEAxis;
    public float zEAxis;

    public float angularSpeed;
    public bool spinCW;
    public bool spinCCW;

    public float radius;

    private Vector3 origin;
    private Vector3 rotationOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (spinCW && spinCCW)
        {
            spinCW = false;
        }

        //rotationOffset = parent.rotation;

        CreateProtector();
    }

    private void Update()
    {
        RotateProtector();
    }

    void CreateProtector()
    {
        //GameObject currentPiece;
        int pieces = 8;

        origin = parent.position;
        
        for (int i = 0; i < pieces; i++)
        {

            Quaternion rotation = Quaternion.Euler(0, 45 * i, 0) * PiecePrefab.transform.rotation;

            GameObject currentPiece = Instantiate(PiecePrefab, origin, rotation, parent) as GameObject;
            
            currentPiece.transform.Find("Spinner").GetComponent<Transform>().localPosition += new Vector3(0, 0, radius);
            currentPiece.transform.Find("Spinner1").GetComponent<Transform>().localPosition += new Vector3(0, 0, radius);
        }

        PiecePrefab.SetActive(false);
        parent.rotation = Quaternion.Euler(xEAxis, yEAxis, zEAxis);
    }

    private void RotateProtector()
    {
        //parent.rotation = Quaternion.Euler(xEAxis, yEAxis, zEAxis);

        float angle = Time.deltaTime * (angularSpeed * Mathf.Rad2Deg);

        if (spinCCW)
        {
            parent.transform.Rotate(0, angle, 0, Space.Self);
        }
        else if (spinCW)
        {
            //parent.transform.Rotate(0, -angle, 0, Space.Self);
            parent.transform.RotateAround(parent.transform.position, new Vector3(xEAxis, yEAxis, zEAxis), angle);
        }
    }
}

// Use to create eliptical orbits
//new Vector3(Mathf.Sin((45 * i) * Mathf.Deg2Rad), 0, Mathf.Cos((45 * i) * Mathf.Deg2Rad));