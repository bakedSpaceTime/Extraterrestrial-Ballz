using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float offset;
    public float explrad;
    public float androidMult;

    private Vector3 accelerationOffset;
    private Rigidbody rb;

    void Start()
    {
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
            Debug.Log(moveHorizontal);
        }
        else
        {
            moveHorizontal = (Input.acceleration.x - PlayerPrefs.GetFloat("ACalX",0)) * androidMult;
            moveVertical = (Input.acceleration.y - PlayerPrefs.GetFloat("ACalY", 0)) * androidMult;
            Debug.Log(moveVertical);
            Debug.Log(Input.acceleration.z);
        }

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(-1f * movement * speed);
      
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
        return Physics.Raycast(transform.position, Vector3.down, out hit) && hit.distance < 1.1f;
    }
}