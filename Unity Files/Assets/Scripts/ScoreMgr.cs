using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMgr : MonoBehaviour
{
    // variables used to track score and kill counts
    public static ScoreMgr instance;
    private int score = 0;

    public void Awake()
    {
        // only keep the first copy of this script around
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // getter and setter functions for score and item/enemy kill counts
    public int GetScore()
    {
        return score;
    }

    public void SetScore(int scoreToSet)
    {
        if (scoreToSet >= 0)
        {
            score += scoreToSet;
        }
    }
}