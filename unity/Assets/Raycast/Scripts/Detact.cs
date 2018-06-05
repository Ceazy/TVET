using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detact : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray interactRay;
            interactRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            RaycastHit hitInfo;
            if (Physics.Raycast(interactRay, out hitInfo, 10))
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Hit Enemy");
                }
            }
        }
	}
}
