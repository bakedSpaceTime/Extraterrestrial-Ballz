using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
   // public GameObject player;
    private Rigidbody rb;

   // [SerializeField]
    public Transform spawnPoint;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -17)
            Reset();
    }

    private void Reset()
    {
        rb = GetComponent<Rigidbody>();

        rb.transform.rotation = Quaternion.identity;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);

        transform.position = spawnPoint.position;
        
    }
}
