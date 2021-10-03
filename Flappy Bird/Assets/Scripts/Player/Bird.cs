using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int score;


    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        score = 0;
        _birdMover.ResetBird();
    }

    public void Die()
    {
        Debug.Log("Die");
        Time.timeScale = 0;
    }
}