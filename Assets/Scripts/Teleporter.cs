using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTo;
    //public GameObject Player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Player.transform.position = teleportTo.position;
            other.gameObject.transform.position = teleportTo.position;
        }
    }
    /*
    private void Transport(Collider obj)
    {
        rb = GetComponent<Collider>().attachedRigidbody;

        rb.transform.position = teleportTo.position;
    }
    */
}
