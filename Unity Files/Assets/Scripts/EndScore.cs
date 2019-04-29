using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text endScore;
    public Text livesLeft;

    // Start is called before the first frame update
    void Awake()
    {
        endScore = GetComponentInChildren<Text>(true);
        //livesLeft = GetComponentInChildren<Text>(true);
    }

    // Update is called once per frame
    void Update()
    {
        FinalScore();
        LivesLeft();
    }

    void FinalScore()
    {
        if (endScore)
        {
            endScore.text = "" + ScoreMgr.instance.GetScore();
        }
    }

    void LivesLeft() {
        if (livesLeft)
        {
            livesLeft.text = "" + HeroStats.instance.livesLeft;
        }
    }
}
