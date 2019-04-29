using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance;
    private AudioSource asource;
    public AudioClip levelTheme;
    public AudioClip playerDeath;
    public AudioClip gameOver;
    public AudioClip roundClear;
    public AudioClip invincible;
    public AudioClip pickUpItem;
    public AudioClip playerJump;
    public AudioClip enemyDeath;
    public AudioClip tomahawkThrow;
    public AudioClip stumbleSound;
    public AudioClip axePickup;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        // create the audiosource if we need it
        if (asource == null)
        {
            asource = this.gameObject.AddComponent<AudioSource>();
            if (asource)
            {
                asource.playOnAwake = false;

            }
        }
    }

    // methods used to play each sound clip, will be called on during run time by appropriate logic
    public void PlayPlayerDeath()
    {
        if (asource != null)
        {
            if (playerDeath != null)
                asource.PlayOneShot(playerDeath);
        }
    }

    public void PlayAxePickup()
    {
        if (asource != null)
        {
            if (axePickup != null)
                asource.PlayOneShot(axePickup);
        }
    }

    public void PlayStumbleSound()
    {
        if (asource != null)
        {
            if (stumbleSound != null)
                asource.PlayOneShot(stumbleSound);
        }
    }

    public void PlayThrow()
    {
        if (asource != null)
        {
            if (tomahawkThrow != null)
                asource.PlayOneShot(tomahawkThrow);
        }
    }

    public void PlayPlayerJump()
    {
        if (asource != null)
        {
            if (playerJump != null)
                asource.PlayOneShot(playerJump);
        }
    }

    public void PlayItemPickUp()
    {
        if (asource != null)
        {
            if (pickUpItem != null)
                asource.PlayOneShot(pickUpItem);
        }
    }

    public void PlayEnemyDeath()
    {
        if (asource != null)
        {
            if (enemyDeath != null)
                asource.PlayOneShot(enemyDeath);
        }
    }

    public void PlayGameOver()
    {
        if (asource != null)
        {
            if (gameOver != null)
                asource.PlayOneShot(gameOver);
        }
    }

    public void PlayRoundClear()
    {
        if (asource != null)
        {
            if (roundClear != null)
                asource.PlayOneShot(roundClear);
        }
    }

    public void PlayInvincible()
    {
        if (asource != null)
        {
            if (invincible != null)
                asource.PlayOneShot(invincible);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (asource != null)
        {
            if (levelTheme != null)
            {
                asource.loop = true;
                asource.clip = levelTheme;
                asource.Play();
            }
        }
    }
}

