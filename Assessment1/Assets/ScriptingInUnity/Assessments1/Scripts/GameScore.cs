using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
            
        }

        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    // Use this for initialization
    void Start()
    {
        //Get text component of this gameObject
        scoreTextUI = GetComponent<Text>();
    }
    //Function to get score text UI
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format ("{0:000000}", score);
        scoreTextUI.text = scoreStr;
    }

     

}
