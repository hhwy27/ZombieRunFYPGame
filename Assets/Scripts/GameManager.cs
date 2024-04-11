using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;
    public Text scoreText;

    public PlayerController playerMovement;

    public void ChangeScore ()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        //increase speed as the level goes on
        playerMovement.speed += playerMovement.speedIncreasePoints;
    }
    
    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
