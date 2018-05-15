using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Movement : MonoBehaviour
    {
        // Units traveling per second
        public float speed = 20f;

        // Amount of rotation per second 
        public float rotationSpeed = 360f;

        // Reference to attacthed Rigidbody2D
        private Rigidbody2D rigid;


        // Use this for initialization
        void Start()
        {
            //Grab Reference to rigidbody2D component 
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //Check if A key is pressed 
            if (Input.GetKey(KeyCode.A))
            {
                // Rotate Left
                transform.Rotate(Vector3.forward, rotationSpeed);
            }
            // Check if D key is pressed 
            if (Input.GetKey(KeyCode.D))
            {
                // Rotate Right 
                transform.Rotate(-Vector3.forward, rotationSpeed);
            }
            // Check if W key is pressed 
            if (Input.GetKey(KeyCode.W))
            {
                // Move in facing direction 
                rigid.AddForce(transform.up * speed);
            }
            // Check if S key is pressed 
            if (Input.GetKey(KeyCode.S))
            {
                // Move in opposite facing direction 
                rigid.AddForce(-transform.up * speed);
            }

        }
    }
}
