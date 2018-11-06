/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        BlinkerControl.cs
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkerControl : MonoBehaviour {
    public GameObject blinkerLeft;
    public GameObject blinkerRight;
    private Renderer lr;
    private Renderer rr;
    private AudioSource la;
    private AudioSource ra;

	// Use this for initialization
	void Start () {
        la = blinkerLeft.GetComponent<AudioSource>();
        ra = blinkerRight.GetComponent<AudioSource>();
        lr = blinkerLeft.GetComponent<Renderer>();
        rr = blinkerRight.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (lr.enabled == false)
            {
                rr.enabled = false;
                ra.Stop();
                lr.enabled = true;
                la.Play();
            }
            else
            {
                lr.enabled = false;
                la.Stop();
            }

        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (rr.enabled == false)
            {
                lr.enabled = false;
                la.Stop();
                rr.enabled = true;
                ra.Play();
            }
            else
            {
                rr.enabled = false;
                ra.Stop();
            }
        }
    }
}
