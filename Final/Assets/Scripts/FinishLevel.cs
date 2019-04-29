using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    AudioSource gameLevelAudioSrc;
    public GameObject levelCompletePanel;
    public GameObject gameLevel;

    public void Awake() {
        gameLevelAudioSrc = GameObject.Find("GameLevel").GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
       
        LevelComplete();
    }


    public void LevelComplete()
    {
        gameLevelAudioSrc.Stop();
        SoundMgr.instance.PlayRoundClear();
        //StartCoroutine(DelayAction());
        levelCompletePanel.SetActive(true);
        gameLevel.SetActive(false);
        //StopCoroutine(DelayAction());
    }

    IEnumerator DelayAction()
    {
        
        yield return new WaitForSeconds(3);
        
    }
}
