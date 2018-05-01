using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string message = "Hello World!";
    public Rigidbody rigid;
    float speed = 5;
    
        
// Use this for initialization
void Start()
{
       
}

/*
[] - Brackets
{} - Braces
() - Parenthesis

Hot keys: 
- Clean Code: CTRL + K + D
- Fold Code : CTRL + M + O
- UnFold Codd : CTRL + M + P
*/

// Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.W))
    {
            rigid.AddForce(Vector3.forward * speed);
    }
}
}