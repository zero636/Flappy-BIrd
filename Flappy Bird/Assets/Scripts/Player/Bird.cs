using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int score;
    
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }


    public void IncreaseScore()
    {
        score++;
        ScoreChanged?.Invoke(score);
    }
    
    public void ResetPlayer()
    {
        score = 0;
        ScoreChanged?.Invoke(score);
        _birdMover.ResetBird();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}