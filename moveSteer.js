/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        moveSteer.js
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 
#pragma strict

var rotationSpeed : float = 180.0;
static var origRotation : Quaternion;

        function Awake () {

                origRotation = transform.localRotation;
        }

        function Update () {

                        var rotation : float = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

                        transform.Rotate(0, 0, -rotation);

                        transform.localRotation = Quaternion.Slerp(transform.localRotation, origRotation, Time.deltaTime);
        }