using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO; //Enemy Gun Prefab


    // Use this for initialization
    void Start()
    {
        //Fire enemy bullet after 1 second
        Invoke("FireEnemyBullet", 1f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Funtion to fire enemy bullet
    void FireEnemyBullet()
    {
        //Reference to player ship
        GameObject playerShip = GameObject.Find("PlayerGO");

        if(playerShip != null) //Player not dead 

            {
            //Instantiate enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            //Set bullet position
            bullet.transform.position = transform.position;

            //Bullet direction towards player
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //Bullet direction
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

        }
    }
}
