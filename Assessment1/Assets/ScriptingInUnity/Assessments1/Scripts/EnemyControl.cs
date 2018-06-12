using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    GameObject scoreUITextGO; //Reference to the text UI game object

    public GameObject ExplosionGO;

    float speed; //Enemy Speed

    // Use this for initialization
    void Start()
    {
        speed = 2f; //Set speed

        //Get score UI text
        scoreUITextGO = GameObject.FindGameObjectWithTag ("ScoreTextTag");
    }

    // Update is called once per frame
    void Update()
    {
        //Getting enemy position
        Vector2 position = transform.position;

        //Get enemy new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Update enemy position
        transform.position = position;

        //Bottom left of screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //If enemy outside of screen then destroy enemy
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect enemy ship with player 
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))

        {
            PlayExplosion();

            //Add 100 points
            scoreUITextGO.GetComponent<GameScore>().Score += 100;

            Destroy(gameObject);//Destroy enemy 

        }
    }
        void PlayExplosion()
        {
            GameObject explosion = (GameObject)Instantiate(ExplosionGO);

            //Set position of explosion
            explosion.transform.position = transform.position;
        }
    }

