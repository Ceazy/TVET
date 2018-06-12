using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManagerGO; 

    public GameObject PlayerBulletGO;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject ExplosionGO;

    //Reference to lives UI text
    public Text LivesUIText;

    const int MaxLives = 3; //Maximum lives of player
    int Lives; //current lives of player

    public float speed;

    public void Init()
    {
        Lives = MaxLives;

        //Update Lives UI text
        LivesUIText.text = Lives.ToString();

        //Set player game object active
        gameObject.SetActive(true);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Fire when spacebar is pressed
        if (Input.GetKeyDown("space"))
        {
            //Instantiate first bullet
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = bulletPosition01.transform.position;//Set bullet initial position

            //Instantiate second bullet
            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = bulletPosition02.transform.position;//Set bullet initial position
        }

        float x = Input.GetAxisRaw("Horizontal");// Vavlue will be -1, 0, 1 (left, no input and right)
        float y = Input.GetAxisRaw("Vertical");// Vavlue will be -1, 0, 1 (down, no input and up)

        // computing a directional vector - normalise to get a unit vector 
        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);

    }

    void Move(Vector2 direction)
    {
        // The screen limits of player movements

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Bottom left of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //Bottom right of screen

        max.x = max.x - 0.255f; //Subtract the player sprite half width 
        min.y = min.y + 0.255f; //Add the player sprite half width 

        max.x = max.x - 0.285f; //Subtract the player sprite half height
        min.y = min.y + 0.285f; //Add the player sprite half height

        //Players current position
        Vector2 pos = transform.position;

        //Calculate new position
        pos += direction * speed * Time.deltaTime;

        //Ensuring position not outside of screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //Update player position
        transform.position = pos;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of player ship with enemy
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))

        {
            PlayExplosion();
            Lives--; //Subtract 1 live
            LivesUIText.text = Lives.ToString();//Update lives UI Texts
            if (Lives==0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Gameover);
                gameObject.SetActive(false);//Hides player 
            }
        }


    }

    //Function for explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        //Set position of explosion
        explosion.transform.position = transform.position;
    }
}
