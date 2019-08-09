using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float offset;
    public float explrad;
    public float androidMult;

    private Rigidbody rb;
    private float moveHorizontal;
    //private bool isAndroid;

    void Start()
    {
       // isAndroid = true;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal;
        float moveVertical;
        

        if (Application.isEditor)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
          //  isAndroid = false;
        }
        else
        {
            moveHorizontal = Input.acceleration.x * androidMult;
            moveVertical = Input.acceleration.y * androidMult; 
        }
        
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(-1f * movement * speed);
        /*
        if (!isAndroid && (Input.GetAxis("Jump") != 0))
        {
           jump();
        }
        else if (isAndroid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            jump();
        }*/

        if (Input.GetAxis("Fire1") != 0 || Input.GetAxis("Jump") != 0)
        {
            jump();
        }

    }

    private void jump()
    {
        if(isGrounded())
        {
            Vector3 forcePos = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
            rb.AddExplosionForce(jumpForce, forcePos, explrad, 0, ForceMode.Impulse);
        }
    }

    private bool isGrounded()
    {
        RaycastHit hit;

        /*
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            return hit.distance < 1.1f;
        }
        else
        {
            return false;
        } 
        */

         return Physics.Raycast(transform.position, Vector3.down, out hit) && hit.distance < 1.1f;
    }
}