using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierRepel : MonoBehaviour
{
    public float repelForce;
    public float explrad;

    private Rigidbody rb;

    public void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            rb = obj.attachedRigidbody;
            Vector3 forcePos =transform.position;
            rb.AddExplosionForce(repelForce, forcePos, explrad, 0, ForceMode.Impulse);
        }
    }



        
}
