using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralOfDeath : MonoBehaviour
{
    // z scale of prefab is used to determine rotation angle
    // prefab must be oriented to world axis
    public GameObject prefab;
    public Transform parent;
    // used to skip over messy spiral at the bottom
    public int start;
    public int pieces;
    public float a;
    public float b;

    private float radius1;
    private float radius2;
    private float angle = 0;

    private float sidelength;

    void Start()
    {
        CreateSpiral();
    }

    // Update is called once per frame
    private void CreateSpiral()
    {
        for(int i = start; i < pieces; i ++)
        {
            if(RotationAngle(i))
            {
                Quaternion rotation = Quaternion.Euler(InclinationAngle(), -angle * Mathf.Rad2Deg, 10f);
               
                Vector3 position = new Vector3(radius1 * Mathf.Cos(angle), i, radius1 * Mathf.Sin(angle));

                Instantiate(prefab, position + parent.position, rotation, parent);
            }
        }

        prefab.SetActive(false);
    }

    private bool RotationAngle(int i)
    {
        
        float r1sq;
        float r2sq;

        sidelength = prefab.transform.lossyScale.z * 0.8f;
        float sideLsq = Mathf.Pow(sidelength, 2);
        float cosInside;

        radius1 = Mathf.Pow(i, 0.5f);
        radius2 = Mathf.Pow(i + 1, 0.5f);

        r1sq = Mathf.Pow(radius1, 2);
        r2sq = Mathf.Pow(radius2, 2);

        cosInside = (r1sq + r2sq - sideLsq) / (2 * radius1 * radius2);

        //Debug.Log(cosInside);

        if(cosInside >= -1 && cosInside <= 1)
        {
            angle += Mathf.Acos(cosInside);
            return true;
        }
        else
        {
            return false;
        }
    }

    private float InclinationAngle()
    {
        return -Mathf.Asin(1 / (sidelength*  1.1f)) * Mathf.Rad2Deg;
    }
}
