using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float offset;
    public float explrad;
    public float androidMult;

    public Transform mainCamera;

    private Vector3 accelerationOffset;
    private Rigidbody rb;
    private int applicationType;

    private int windowsApp = 0;
    private int editorApp = 1;
    private int androidApp = 2;

    //public FloatingJoystick stik;

    private Vector3 rawMovement;
    private Vector3 movement;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Vector3 movement;
        rawMovement.y = 0f;
        movement.y = 0f;

        //Debug.Log(stik.Horizontal);
        //Debug.Log(Input.GetAxis("Look"));

        if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            rawMovement.x = Input.GetAxis("Horizontal");
            rawMovement.z = Input.GetAxis("Vertical");
        }
        else
        {
            rawMovement.x = (Input.acceleration.x - PlayerPrefs.GetFloat("ACalX",0)) * androidMult;
            rawMovement.z = (Input.acceleration.y - PlayerPrefs.GetFloat("ACalY", 0)) * androidMult;
        }

        float angle = (mainCamera.transform.eulerAngles.y)* Mathf.Deg2Rad;

        movement.x = rawMovement.x * Mathf.Cos(angle) + rawMovement.z * Mathf.Sin(angle);
        movement.z = -rawMovement.x * Mathf.Sin(angle) + rawMovement.z * Mathf.Cos(angle);

        //Debug.Log(movement);
        rb.AddForce(1f * movement * speed);
      
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

    private int DetermineApplicationType()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            return windowsApp;
        }
        else if(Application.isEditor)
        {
            return editorApp;
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            return androidApp;
        }

        return -1;
    }
}