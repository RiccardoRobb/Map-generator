using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
     
         public float lookSpeedH = 2f;
         public float lookSpeedV = 2f;
         public float zoomSpeed = 2f;
         public float dragSpeed = 6f;
     
         private float yaw = 0f;
         private float pitch = 0f;
         
         void Start(){
            transform.eulerAngles = new Vector3(30.1f, 0.8f, 0.0f);
            transform.position = new Vector3(-1.9f, 11.1f, -26.4f);
         }

         void Update ()
         {
            /*
             if (Input.GetKeyDown("s")){
                print(transform.eulerAngles);
                print(transform.position);
             }*/
             
             //Look around with Right Mouse
             if (Input.GetMouseButton(1))
             {
                 yaw += lookSpeedH * Input.GetAxis("Mouse X");
                 pitch -= lookSpeedV * Input.GetAxis("Mouse Y");
     
                 transform.eulerAngles = new Vector3(pitch, yaw, 0f);
             }
     
             //drag camera around with Middle Mouse
             if (Input.GetMouseButton(2))
             {
                 transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * dragSpeed,   -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * dragSpeed, 0);
             }
     
             //Zoom in and out with Mouse Wheel
             transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, Space.Self);
         }
     }
