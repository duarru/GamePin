﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private Text scoreText;
    private int score;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        if(instance == null)
        {
            instance = this;
        }
    }
    public void SetScore()
    {
        score++;
        scoreText.text = "" + score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
