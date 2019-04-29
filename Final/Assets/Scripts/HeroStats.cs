// HeroStats script is used to keep track of player health, number of lives, respawn points and calling end of life/game over panels.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStats : MonoBehaviour
{
    // variables to control health, lives, panels and spawn positions
    AudioSource gameLevelAudioSrc;
    public static HeroStats instance;
    public GameObject hero;
    private CharacterController myController;
    public Transform healthBar;
    public Slider healthFill;
    public Image fill;
    public float currentHealth, maxHealth;
    public GameObject healthPanel;
    public GameObject gameOverPanel;
    public int livesLeft;
    public Transform spawnPosition;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    public Transform spawnPosition4;
    public GameObject gameCamera;

    // Create a singlton instance for this script to ensure only one is ever created
    public void Awake()
    {
        // only keep the first copy of this script around
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        gameLevelAudioSrc = GameObject.Find("GameLevel").GetComponent<AudioSource>();
        GameObject.Find("GameLevel").SetActive(false);
    }

    // method used to keep track of player health/lives and call approipriate panels after death
    public void ChangeHealth(int healthAmount)
    {
        // set up health bar
        currentHealth += healthAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthFill.value = currentHealth / maxHealth;

        //change color of health bar dependant on current health (red for low health, yellow for mid range, and green for high health)
        if (currentHealth >= 75)
        {
            fill.color = Color.green;
        }
        else if (currentHealth > 25 && currentHealth < 75)
        {
            fill.color = Color.yellow;
        }
        else if (currentHealth < 25 && currentHealth > 0) {
            fill.color = Color.red;
        }
        // decrement lives when player reaches zero health, respawn to closest checkpoint, call panels
        else if (currentHealth <= 0) {
            livesLeft--;
            

            if (livesLeft > 0)
            {
                
                gameLevelAudioSrc.Pause();
               
                StartCoroutine(DelayAction());
                StopCoroutine(DelayAction());

                currentHealth = 100;
                healthFill.value = currentHealth / maxHealth;
                fill.color = Color.green;
                myController.enabled = false;
                
            }
            else if (livesLeft <= 0)
            {
                gameLevelAudioSrc.Stop();
                SoundMgr.instance.PlayGameOver();
                healthPanel.SetActive(false);
                gameOverPanel.SetActive(true);
                GameObject.Find("GameLevel").SetActive(false);
            }
        }
    }

    private void SpawnPlayer() {
        if (myController.transform.position.x > spawnPosition2.position.x
                    && myController.transform.position.x < spawnPosition3.position.x)
        {
            myController.transform.position = spawnPosition2.position;
        }
        else if (myController.transform.position.x > spawnPosition3.position.x
            && myController.transform.position.x < spawnPosition4.position.x)
        {
            myController.transform.position = spawnPosition3.position;
        }
        else if (myController.transform.position.x > spawnPosition4.position.x)
        {
            myController.transform.position = spawnPosition4.position;
        }
        else
        {
            myController.transform.position = spawnPosition.position;
        }
        myController.enabled = true;
    }

    IEnumerator DelayAction() {
        hero.GetComponent<Animator>().SetTrigger("death");
        SoundMgr.instance.PlayPlayerDeath();
        yield return new WaitForSeconds(3);
        PauseScript.instance.continuePanel.SetActive(true);
        Time.timeScale = 0f;
        SpawnPlayer();
        gameLevelAudioSrc.UnPause();
    }

    // Start is called before the first frame update
    void Start()
    {
        myController = hero.GetComponent<CharacterController>();
        livesLeft = 3;
    }
}
