using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningProtector : MonoBehaviour
{
    public GameObject PiecePrefab;
    public Transform parent;

    public bool xAxis;
    public bool yAxis;
    public bool zAxis;

    private Vector3 origin;
    private Vector3 rotationOffset;

    // Start is called before the first frame update
    void Start()
    {
        CreateProtector();
    }

    void CreateProtector()
    {
        AxisCheck();
        int pieces = 8;

        origin = parent.position;
        //rotationOffset = parent.rotation;

        for(int i = 0; i < pieces; i++)
        {
            if (xAxis)
            {
                Vector3 position = Vector3.zero;
                Quaternion rotation = Quaternion.Euler(45 * i, 0, 0) * PiecePrefab.transform.rotation;

                Instantiate(PiecePrefab, position + origin, rotation, parent);
            }
            else if(zAxis)
            {
                Vector3 position = Vector3.zero;
                Quaternion rotation = Quaternion.Euler(0, 0, 45 * i) * PiecePrefab.transform.rotation;

                Instantiate(PiecePrefab, position + origin, rotation, parent);
            }
            else
            {
                Vector3 position = Vector3.zero;
                Quaternion rotation = Quaternion.Euler(0, 45 * i, 0) * PiecePrefab.transform.rotation;

                Instantiate(PiecePrefab, position + origin, rotation, parent);
            }
            
           
        }

        PiecePrefab.SetActive(false);
    }

    private void AxisCheck()
    {
        if(xAxis && yAxis && zAxis)
        {
            xAxis = false;
            zAxis = false;
        }
        else if(yAxis && xAxis)
        {
            xAxis = false;
        }
        else if(xAxis && zAxis)
        {
            zAxis = false;
        }
        else if(zAxis && yAxis)
        {
            yAxis = false;
        }
    }
}

// Use to create eliptical orbits
//new Vector3(Mathf.Sin((45 * i) * Mathf.Deg2Rad), 0, Mathf.Cos((45 * i) * Mathf.Deg2Rad));