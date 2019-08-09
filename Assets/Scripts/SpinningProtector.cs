using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningProtector : MonoBehaviour
{
    public GameObject PiecePrefab;
    public Transform parent;

    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        CreateProtector();
    }

    void CreateProtector()
    {
        int pieces = 8;

        origin = parent.position;

        for(int i = 0; i < pieces; i++)
        {
            Vector3 position = Vector3.zero;
            
            // Use to create eliptical orbits
            //new Vector3(Mathf.Sin((45 * i) * Mathf.Deg2Rad), 0, Mathf.Cos((45 * i) * Mathf.Deg2Rad));

            Quaternion rotation = Quaternion.Euler(0, 45 * i, 0);

            //Instantiate(PiecePrefab, position, rotation, PiecePrefab.transform);
            Instantiate(PiecePrefab, position + origin, rotation, parent);
           
        }

        PiecePrefab.SetActive(false);
    }
}
