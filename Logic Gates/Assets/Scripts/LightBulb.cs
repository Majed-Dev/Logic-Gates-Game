using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    public bool bulbOn;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite onSprite, offSprite;
    [SerializeField] Line line;
    AudioManager audioManager;
    private bool winAudioPlayed;
    void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (line.getIsActive())
        {
            bulbOn = true;
            spriteRenderer.sprite = onSprite;
            spriteRenderer.color = Color.yellow;
            PlayWinSound();

        }
        else
        {
            bulbOn= false;
            winAudioPlayed = false;
            spriteRenderer.sprite = offSprite;
            spriteRenderer.color = Color.white;
        }
    }
    private void PlayWinSound()
    {
        if (!winAudioPlayed)
        {
            audioManager.PlaySFX(audioManager.lightOn);
            winAudioPlayed = true;
        }

    }

}
