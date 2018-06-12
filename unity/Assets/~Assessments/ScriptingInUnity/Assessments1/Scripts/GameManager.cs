using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Reference to game objects 
    public GameObject playButton;
    public GameObject playerShip;


    public enum GameManagerState
    {
        Opening,
        Gameplay,
        Gameover,
    }

    GameManagerState GMState;
    // Use this for initialization
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    //Function to update game manager state 
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                //Hide game over 

                //Set play button to visible 

                


                break;
            case GameManagerState.Gameplay:

                //Hide play button when playing 
                playButton.SetActive(false);

                //Set the player visible and enable lives
                playerShip.GetComponent<PlayerControl>().Init();

                break;

            case GameManagerState.Gameover:

                //Stop enemy spawner

                //Display Game over

                //Change game manager state to opening state

                break;
        }
    }
    //Function to set game manager state 
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }   

    public void StartGameplay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState ();
    }
}
