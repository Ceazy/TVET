using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    // Use this for initialization
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get bullet current position 
        Vector2 position = transform.position;

        //Compute bullet's new position 
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //Update bullet position 
        transform.position = position;

        // Top-right of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //When bullet goes outside of top of screen, destroys it
        if (transform.position.y > max.y )
            {
            Destroy(gameObject);
        }
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of player bullet on enemy ship
        if((col.tag == "EnemyShipTag"))
        {
            Destroy(gameObject);//Destroy Enemy
        }
    }

}
