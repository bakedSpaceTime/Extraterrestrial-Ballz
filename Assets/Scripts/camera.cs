using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camera : MonoBehaviour
{
    public float sensitivity;
    public CinemachineVirtualCamera cam;
    public FloatingJoystick stik;

    //private Component comp;

    void Start()
    {
        //comp = cam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        var comp = cam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        comp.m_XAxis.m_InputAxisValue = stik.Horizontal * sensitivity;

        Debug.Log(comp.m_XAxis.m_InputAxisValue);
    }
}
